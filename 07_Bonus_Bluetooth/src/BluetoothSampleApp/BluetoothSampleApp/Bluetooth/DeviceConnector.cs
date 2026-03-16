using BluetoothSampleApp.Models;
using BluetoothSampleApp.Permissions;
using Plugin.BLE;
using Plugin.BLE.Abstractions.Contracts;
using Plugin.BLE.Abstractions.EventArgs;

namespace BluetoothSampleApp.Bluetooth;

/// <summary>
/// Manages BLE device connections and discovers UART service characteristics.
/// </summary>
public class DeviceConnector : IDeviceConnector, IDisposable
{
    // Well-known UART Service and Characteristic UUIDs (Nordic UART Service)
    private static readonly Guid UartServiceId = Guid.Parse("6e400001-b5a3-f393-e0a9-e50e24dcca9e");
    private static readonly Guid UartTxCharacteristicId = Guid.Parse("6e400002-b5a3-f393-e0a9-e50e24dcca9e");
    private static readonly Guid UartRxCharacteristicId = Guid.Parse("6e400003-b5a3-f393-e0a9-e50e24dcca9e");

    private readonly IAdapter _adapter;

    private IDevice? _connectedDevice;

    /// <inheritdoc />
    public event EventHandler? ConnectionLost;

    public bool IsConnected => _connectedDevice?.State == Plugin.BLE.Abstractions.DeviceState.Connected;
    public ICharacteristic? TxCharacteristic { get; private set; }
    public ICharacteristic? RxCharacteristic { get; private set; }

    public DeviceConnector()
    {
        _adapter = CrossBluetoothLE.Current.Adapter;
        _adapter.DeviceConnectionLost += OnDeviceConnectionLost;
    }

    private void OnDeviceConnectionLost(object? sender, DeviceErrorEventArgs args)
    {
        if (_connectedDevice is not null && args.Device.Id == _connectedDevice.Id)
        {
            _connectedDevice = null;
            TxCharacteristic = null;
            RxCharacteristic = null;
            ConnectionLost?.Invoke(this, EventArgs.Empty);
        }
    }

    public async Task ConnectAsync(BluetoothDevice device, CancellationToken cancellationToken = default)
    {
        await BluetoothPermissionHelper.EnsurePermissionsAsync();

        if (IsConnected)
        {
            await DisconnectAsync(cancellationToken);
        }

        var deviceId = Guid.Parse(device.Address);

        // Try to find the device from known/discovered devices first
        var bleDevice = _adapter.DiscoveredDevices.FirstOrDefault(d => d.Id == deviceId);

        if (bleDevice is null)
        {
            try
            {
                bleDevice = await _adapter.ConnectToKnownDeviceAsync(deviceId, cancellationToken: cancellationToken);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Device with address {device.Address} not found.", ex);
            }
        }
        else
        {
            await _adapter.ConnectToDeviceAsync(bleDevice, cancellationToken: cancellationToken);
        }

        _connectedDevice = bleDevice;

        // Request a larger MTU to avoid JSON message truncation.
        // Android defaults to 23-byte ATT MTU (20 bytes usable), which is too small
        // for serialized JSON messages. Windows negotiates a larger MTU automatically.
        await bleDevice.RequestMtuAsync(512, cancellationToken);

        // Discover UART service and characteristics
        var service = await bleDevice.GetServiceAsync(UartServiceId, cancellationToken);
        if (service is null)
        {
            await DisconnectAsync(cancellationToken);
            throw new InvalidOperationException("UART service not found on the device.");
        }

        TxCharacteristic = await service.GetCharacteristicAsync(UartTxCharacteristicId);
        RxCharacteristic = await service.GetCharacteristicAsync(UartRxCharacteristicId);

        if (TxCharacteristic is null || RxCharacteristic is null)
        {
            await DisconnectAsync(cancellationToken);
            throw new InvalidOperationException("Required UART characteristics not found on the device.");
        }
    }

    public async Task DisconnectAsync(CancellationToken cancellationToken = default)
    {
        if (_connectedDevice is not null)
        {
            try
            {
                await _adapter.DisconnectDeviceAsync(_connectedDevice);
            }
            catch
            {
                // Best-effort cleanup
            }
        }

        _connectedDevice = null;
        TxCharacteristic = null;
        RxCharacteristic = null;
    }

    public void Dispose()
    {
        _adapter.DeviceConnectionLost -= OnDeviceConnectionLost;
        DisconnectAsync().GetAwaiter().GetResult();
        GC.SuppressFinalize(this);
    }
}

