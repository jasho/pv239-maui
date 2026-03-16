import bluetooth
import json
import os
import time
from machine import Pin, PWM
from micropython import const

# ============================================================
# PIN-TO-COLOR MAPPING
# If the colors are wrong, swap the pin numbers below.
# ============================================================
PIN_RED = 13
PIN_GREEN = 14
PIN_BLUE = 15
# ============================================================

DEVICE_NAME = "MyBluetoothLight"

# Nordic UART Service UUIDs (must match BluetoothService.cs)
_UART_UUID = bluetooth.UUID("6e400001-b5a3-f393-e0a9-e50e24dcca9e")
_UART_TX_UUID = bluetooth.UUID("6e400002-b5a3-f393-e0a9-e50e24dcca9e")  # Central writes here
_UART_RX_UUID = bluetooth.UUID("6e400003-b5a3-f393-e0a9-e50e24dcca9e")  # Central reads/subscribes here

# BLE IRQ event constants
_IRQ_CENTRAL_CONNECT = const(1)
_IRQ_CENTRAL_DISCONNECT = const(2)
_IRQ_GATTS_WRITE = const(3)

# Characteristic flags
_FLAG_READ = const(0x0002)
_FLAG_WRITE_NO_RESPONSE = const(0x0004)
_FLAG_WRITE = const(0x0008)
_FLAG_NOTIFY = const(0x0010)

# GATT service definition
_UART_SERVICE = (
    _UART_UUID,
    (
        (_UART_TX_UUID, _FLAG_WRITE | _FLAG_WRITE_NO_RESPONSE),
        (_UART_RX_UUID, _FLAG_READ | _FLAG_NOTIFY),
    ),
)


class RGBLed:
    """Controls an RGB LED via PWM on three GPIO pins."""

    def __init__(self, pin_red, pin_green, pin_blue):
        self._pwm_r = PWM(Pin(pin_red))
        self._pwm_g = PWM(Pin(pin_green))
        self._pwm_b = PWM(Pin(pin_blue))
        for pwm in (self._pwm_r, self._pwm_g, self._pwm_b):
            pwm.freq(1000)
            pwm.duty_u16(0)
        self.red = 0
        self.green = 0
        self.blue = 0
        self.brightness = 1.0

    def set_color(self, red, green, blue, brightness=1.0):
        self.red = max(0, min(255, int(red)))
        self.green = max(0, min(255, int(green)))
        self.blue = max(0, min(255, int(blue)))
        self.brightness = max(0.0, min(1.0, float(brightness)))
        # Scale 0-255 → 0-65535 and apply brightness
        self._pwm_r.duty_u16(int(self.red * self.brightness * 257))
        self._pwm_g.duty_u16(int(self.green * self.brightness * 257))
        self._pwm_b.duty_u16(int(self.blue * self.brightness * 257))

    def get_color_dict(self):
        return {
            "Red": self.red,
            "Green": self.green,
            "Blue": self.blue,
            "Brightness": self.brightness,
        }


class BLEPeripheral:
    """BLE peripheral implementing the Nordic UART Service for the MAUI app."""

    def __init__(self, led):
        self._led = led
        self._ble = bluetooth.BLE()
        self._ble.active(True)
        self._ble.irq(self._irq)
        ((self._tx_handle, self._rx_handle),) = self._ble.gatts_register_services(
            (_UART_SERVICE,)
        )
        # Allow larger writes (JSON messages can exceed the default 20-byte MTU)
        self._ble.gatts_set_buffer(self._tx_handle, 512)
        self._ble.gatts_set_buffer(self._rx_handle, 512)
        self._connections = set()
        self._rx_queue = []
        self._advertise()

    # ---- BLE event handler --------------------------------------------------

    def _irq(self, event, data):
        if event == _IRQ_CENTRAL_CONNECT:
            conn_handle, _, _ = data
            self._connections.add(conn_handle)
            print("Connected:", conn_handle)
            self._advertise()  # Keep advertising for additional connections

        elif event == _IRQ_CENTRAL_DISCONNECT:
            conn_handle, _, _ = data
            self._connections.discard(conn_handle)
            print("Disconnected:", conn_handle)
            self._advertise()

        elif event == _IRQ_GATTS_WRITE:
            conn_handle, value_handle = data
            if value_handle == self._tx_handle:
                value = self._ble.gatts_read(self._tx_handle)
                # Copy data and defer processing to the main loop;
                # doing JSON + gatts_notify inside the IRQ is unreliable.
                self._rx_queue.append((conn_handle, bytes(value)))

    # ---- Queue processing (called from main loop) ---------------------------

    def process_messages(self):
        while self._rx_queue:
            conn_handle, data = self._rx_queue.pop(0)
            self._handle_message(conn_handle, data)

    # ---- Message handling ---------------------------------------------------

    def _handle_message(self, conn_handle, data):
        try:
            raw = data.decode("utf-8")
            print("<< IN [conn=%d]: %s" % (conn_handle, raw))
            message = json.loads(raw)
            msg_type = message.get("Type", "")
            msg_id = message.get("Id", "")

            if msg_type == "SetColorRequest":
                payload = json.loads(message.get("Payload", "{}"))
                color = payload.get("Color", {})
                self._led.set_color(
                    color.get("Red", 0),
                    color.get("Green", 0),
                    color.get("Blue", 0),
                    color.get("Brightness", 1.0),
                )
                self._send_response(conn_handle, msg_id, "ColorUpdated",
                                    {"Color": self._led.get_color_dict()})

            elif msg_type == "GetColor":
                self._send_response(conn_handle, msg_id, "ColorUpdated",
                                    {"Color": self._led.get_color_dict()})

            else:
                self._send_response(conn_handle, msg_id, "Error",
                                    {"Message": "Unknown type: " + msg_type})

        except Exception as e:
            print("Error handling message:", e)

    def _send_response(self, conn_handle, request_id, msg_type, payload):
        response = {
            "Id": _generate_uuid(),
            "ResponseToId": request_id,
            "Timestamp": _iso_timestamp(),
            "Type": msg_type,
            "Payload": json.dumps(payload),
        }
        raw_out = json.dumps(response)
        print(">> OUT [conn=%d]: %s" % (conn_handle, raw_out))
        try:
            self._ble.gatts_notify(
                conn_handle, self._rx_handle, raw_out.encode("utf-8")  # type: ignore[call-arg]
            )
        except Exception as e:
            print("Error sending response:", e)

    # ---- Advertising --------------------------------------------------------

    def _advertise(self):
        name_bytes = DEVICE_NAME.encode("utf-8")
        # Build advertising payload: Flags + Complete Local Name
        adv_data = (
            bytearray([0x02, 0x01, 0x06])
            + bytearray([len(name_bytes) + 1, 0x09])
            + name_bytes
        )
        self._ble.gap_advertise(100_000, adv_data=adv_data, connectable=True)  # type: ignore[call-arg]
        print("Advertising as", DEVICE_NAME)


# ---- Helpers ----------------------------------------------------------------

def _generate_uuid():
    b = os.urandom(16)
    return "{:08x}-{:04x}-4{:03x}-{:04x}-{:012x}".format(
        int.from_bytes(b[0:4], "big"),
        int.from_bytes(b[4:6], "big"),
        int.from_bytes(b[6:8], "big") & 0x0FFF,
        (int.from_bytes(b[8:10], "big") & 0x3FFF) | 0x8000,
        int.from_bytes(b[10:16], "big"),
    )


def _iso_timestamp():
    t = time.localtime()
    return "{:04d}-{:02d}-{:02d}T{:02d}:{:02d}:{:02d}Z".format(*t[:6])


# ---- Main -------------------------------------------------------------------

def main():
    led = RGBLed(PIN_RED, PIN_GREEN, PIN_BLUE)
    print("BLE UART peripheral starting...")
    peripheral = BLEPeripheral(led)
    print("Running. Waiting for connections...")
    while True:
        peripheral.process_messages()
        time.sleep_ms(50)


if __name__ == "__main__":
    main()
