using PV239_07_Bonus_Bluetooth.Models;

namespace PV239_07_Bonus_Bluetooth.Bluetooth;

public interface IBluetoothService
{
    bool IsConnected { get; }
    
    Task<List<DeviceModel>> ScanForDevicesAsync();

    Task ConnectToDeviceAsync(Guid deviceId);
    
    Task DisconnectAsync();

    Task SendMessageAsync(string content);

    event EventHandler<string>? MessageReceived;
    
    event EventHandler? Disconnected;
}