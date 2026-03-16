using BluetoothSampleApp.Messages;
using BluetoothSampleApp.Models;

namespace BluetoothSampleApp.Bluetooth;

public interface IBluetoothService
{
    /// <summary>
    /// Indicates whether a device is currently connected.
    /// </summary>
    bool IsConnected { get; }

    /// <summary>
    /// Raised when an unsolicited notification message is received from the device
    /// (i.e., a message that is not a response to a previously sent request).
    /// </summary>
    event EventHandler<Message>? NotificationReceived;

    /// <summary>
    /// Raised when the connection to the device is lost unexpectedly.
    /// </summary>
    event EventHandler? Disconnected;

    /// <summary>
    /// Scans for nearby BLE devices whose name starts with "MyBluetoothLight".
    /// </summary>
    Task<IReadOnlyList<BluetoothDevice>> ScanForDevicesAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Connects to the specified BLE device and sets up UART communication.
    /// </summary>
    Task ConnectAsync(BluetoothDevice device, CancellationToken cancellationToken = default);

    /// <summary>
    /// Disconnects from the currently connected device.
    /// </summary>
    Task DisconnectAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Sends a message to the connected device and waits for a correlated response.
    /// Includes retry and timeout resilience via Polly.
    /// </summary>
    Task<Message> SendMessageAsync(Message message, CancellationToken cancellationToken = default);
}

