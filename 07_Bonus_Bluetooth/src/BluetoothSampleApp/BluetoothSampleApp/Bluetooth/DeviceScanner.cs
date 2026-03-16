using BluetoothSampleApp.Models;
using BluetoothSampleApp.Permissions;
using Plugin.BLE;
using Plugin.BLE.Abstractions.Contracts;
using Plugin.BLE.Abstractions.EventArgs;

namespace BluetoothSampleApp.Bluetooth;

/// <summary>
/// Scans for nearby BLE devices whose name starts with a configured prefix.
/// </summary>
public class DeviceScanner : IDeviceScanner
{
    private const string DeviceNamePrefix = "MyBluetoothLight";
    private static readonly TimeSpan ScanTimeout = TimeSpan.FromSeconds(10);

    private readonly IAdapter _adapter;
    private readonly IBluetoothLE _bluetoothLe;

    public DeviceScanner()
    {
        _bluetoothLe = CrossBluetoothLE.Current;
        _adapter = CrossBluetoothLE.Current.Adapter;
        _adapter.ScanTimeout = (int)ScanTimeout.TotalMilliseconds;
    }

    public async Task<IReadOnlyList<BluetoothDevice>> ScanAsync(CancellationToken cancellationToken = default)
    {
        await BluetoothPermissionHelper.EnsurePermissionsAsync();

        if (_bluetoothLe.State != BluetoothState.On)
        {
            throw new InvalidOperationException($"Bluetooth is not available. Current state: {_bluetoothLe.State}");
        }

        var discoveredDevices = new List<BluetoothDevice>();

        _adapter.DeviceDiscovered += OnDeviceDiscovered;

        try
        {
            await _adapter.StartScanningForDevicesAsync(
                deviceFilter: d => d.Name?.StartsWith(DeviceNamePrefix, StringComparison.OrdinalIgnoreCase) == true,
                cancellationToken: cancellationToken);
        }
        finally
        {
            _adapter.DeviceDiscovered -= OnDeviceDiscovered;
        }

        return discoveredDevices.AsReadOnly();

        void OnDeviceDiscovered(object? sender, DeviceEventArgs args)
        {
            if (args.Device.Name?.StartsWith(DeviceNamePrefix, StringComparison.OrdinalIgnoreCase) == true)
            {
                discoveredDevices.Add(new BluetoothDevice
                {
                    Name = args.Device.Name,
                    Address = args.Device.Id.ToString(),
                    SignalStrength = args.Device.Rssi,
                });
            }
        }
    }
}


