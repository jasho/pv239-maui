using BluetoothSampleApp.Models;

namespace BluetoothSampleApp.Bluetooth;

/// <summary>
/// Responsible for scanning for nearby BLE devices.
/// </summary>
public interface IDeviceScanner
{
    /// <summary>
    /// Scans for nearby BLE devices matching the configured filter.
    /// </summary>
    Task<IReadOnlyList<BluetoothDevice>> ScanAsync(CancellationToken cancellationToken = default);
}

