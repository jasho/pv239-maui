using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PV239_07_Bonus_Bluetooth.Bluetooth;

namespace PV239_07_Bonus_Bluetooth.ViewModels;

[QueryProperty(nameof(DeviceId), nameof(DeviceId))]
public partial class ChatViewModel : BaseViewModel
{
    private readonly IBluetoothService _bluetoothService;

    public ChatViewModel(IBluetoothService bluetoothService)
    {
        _bluetoothService = bluetoothService;
        _bluetoothService.MessageReceived += OnMessageReceived;
        _bluetoothService.Disconnected += OnDisconnected;
    }
    
    public Guid DeviceId { get; set; }

    [ObservableProperty]
    public partial string LastMessage { get; set; }
    
    [RelayCommand]
    private async Task SendMessageAsync(string message)
    {
        await _bluetoothService.SendMessageAsync(message);
    }
    
    public override async Task OnPageLoaded()
    {
        await base.OnPageLoaded();
        
        await _bluetoothService.ConnectToDeviceAsync(DeviceId);
    }

    public override async Task OnPageUnloaded()
    {
        await base.OnPageUnloaded();

        await _bluetoothService.DisconnectAsync();
    }

    private void OnDisconnected(object? sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }

    private void OnMessageReceived(object? sender, string e)
    {
        LastMessage = e;
    }
}