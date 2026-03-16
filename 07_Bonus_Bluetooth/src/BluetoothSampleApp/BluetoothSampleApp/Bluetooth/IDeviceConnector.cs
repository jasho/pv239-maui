using BluetoothSampleApp.Models;
using Plugin.BLE.Abstractions.Contracts;

namespace BluetoothSampleApp.Bluetooth;

/// <summary>
/// Responsible for connecting to and disconnecting from BLE devices.
/// Exposes the connected device's UART characteristics for message transport.
/// </summary>
public interface IDeviceConnector
{
    /// <summary>
    /// Raised when the connection to the device is lost unexpectedly.
    /// </summary>
    event EventHandler? ConnectionLost;

    /// <summary>
    /// Indicates whether a device is currently connected.
    /// </summary>
    bool IsConnected { get; }

    /// <summary>
    /// The TX (write) characteristic of the connected device, or null if not connected.
    /// </summary>
    ICharacteristic? TxCharacteristic { get; }

    /// <summary>
    /// The RX (notify) characteristic of the connected device, or null if not connected.
    /// </summary>
    ICharacteristic? RxCharacteristic { get; }

    /// <summary>
    /// Connects to the specified BLE device and discovers UART characteristics.
    /// </summary>
    Task ConnectAsync(BluetoothDevice device, CancellationToken cancellationToken = default);

    /// <summary>
    /// Disconnects from the currently connected device.
    /// </summary>
    Task DisconnectAsync(CancellationToken cancellationToken = default);
}

