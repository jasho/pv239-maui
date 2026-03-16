using PV239_07_Bonus_Bluetooth.Models;

namespace PV239_07_Bonus_Bluetooth.Bluetooth;

public class BluetoothService : IBluetoothService
{
    public bool IsConnected { get; private set; }

    public Task<List<DeviceModel>> ScanForDevicesAsync()
    {
        return Task.FromResult(new List<DeviceModel>
        {
            new("Device 1", Guid.NewGuid())
        });
    }

    public Task ConnectToDeviceAsync(Guid deviceId)
    {
        IsConnected = true;
        return Task.CompletedTask;
    }

    public Task DisconnectAsync()
    {
        IsConnected = false;
        return Task.CompletedTask;
    }

    public Task SendMessageAsync(string content)
    {
        MessageReceived?.Invoke(this, content.ToUpper());
        return Task.CompletedTask;
    }

    public event EventHandler<string>? MessageReceived;
    
    public event EventHandler? Disconnected;
}