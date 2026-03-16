import bluetooth
import time
from micropython import const

DEVICE_NAME = "EchoUpper"

# Nordic UART Service UUIDs
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


class BLEUpperEcho:
    """BLE peripheral that echoes received strings back as upper-case."""

    def __init__(self):
        self._ble = bluetooth.BLE()
        self._ble.active(True)
        self._ble.irq(self._irq)
        ((self._tx_handle, self._rx_handle),) = self._ble.gatts_register_services(
            (_UART_SERVICE,)
        )
        self._ble.gatts_set_buffer(self._tx_handle, 512)
        self._ble.gatts_set_buffer(self._rx_handle, 512)
        self._connections = set()
        self._rx_queue = []
        self._advertise()

    def _irq(self, event, data):
        if event == _IRQ_CENTRAL_CONNECT:
            conn_handle, _, _ = data
            self._connections.add(conn_handle)
            print("Connected:", conn_handle)
            self._advertise()

        elif event == _IRQ_CENTRAL_DISCONNECT:
            conn_handle, _, _ = data
            self._connections.discard(conn_handle)
            print("Disconnected:", conn_handle)
            self._advertise()

        elif event == _IRQ_GATTS_WRITE:
            conn_handle, value_handle = data
            if value_handle == self._tx_handle:
                value = self._ble.gatts_read(self._tx_handle)
                self._rx_queue.append((conn_handle, bytes(value)))

    def process_messages(self):
        while self._rx_queue:
            conn_handle, data = self._rx_queue.pop(0)
            self._handle_message(conn_handle, data)

    def _handle_message(self, conn_handle, data):
        try:
            text = data.decode("utf-8")
            print("<< IN [conn=%d]: %s" % (conn_handle, text))
            response = text.upper()
            print(">> OUT [conn=%d]: %s" % (conn_handle, response))
            self._ble.gatts_notify(
                conn_handle, self._rx_handle, response.encode("utf-8")  # type: ignore[call-arg]
            )
        except Exception as e:
            print("Error handling message:", e)

    def _advertise(self):
        name_bytes = DEVICE_NAME.encode("utf-8")
        adv_data = (
            bytearray([0x02, 0x01, 0x06])
            + bytearray([len(name_bytes) + 1, 0x09])
            + name_bytes
        )
        self._ble.gap_advertise(100_000, adv_data=adv_data, connectable=True)  # type: ignore[call-arg]
        print("Advertising as", DEVICE_NAME)


def main():
    print("BLE Upper-Echo server starting...")
    server = BLEUpperEcho()
    print("Running. Waiting for connections...")
    while True:
        server.process_messages()
        time.sleep_ms(50)


if __name__ == "__main__":
    main()
