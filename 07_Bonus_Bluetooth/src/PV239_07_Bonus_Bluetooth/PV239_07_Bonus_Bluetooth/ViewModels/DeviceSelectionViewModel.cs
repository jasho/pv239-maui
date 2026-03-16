using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PV239_07_Bonus_Bluetooth.Bluetooth;
using PV239_07_Bonus_Bluetooth.Models;

namespace PV239_07_Bonus_Bluetooth.ViewModels;

public partial class DeviceSelectionViewModel(
    IBluetoothService bluetoothService) : BaseViewModel
{
    [ObservableProperty]
    public partial ReadOnlyCollection<DeviceModel> Devices { get; set; }
    
    public override async Task OnPageLoaded()
    {
        await base.OnPageLoaded();
        
        await ScanDevicesCommand.ExecuteAsync(null);
    }

    [RelayCommand]
    private async Task SelectDeviceAsync(DeviceModel device)
    {
        await Shell.Current.GoToAsync($"chat?id={device.Id}");
    }

    [RelayCommand]
    private async Task ScanDevicesAsync()
    {
        var devices = await bluetoothService.ScanForDevicesAsync();
        Devices = new ReadOnlyCollection<DeviceModel>(devices);
    }
}