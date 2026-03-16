using System.Collections.ObjectModel;
using BluetoothSampleApp.Bluetooth;
using BluetoothSampleApp.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BluetoothSampleApp.ViewModels;

public partial class DeviceSelectionViewModel : BaseViewModel
{
    private readonly IBluetoothService _bluetoothService;

    [ObservableProperty]
    public partial BluetoothDevice? SelectedDevice { get; set; }

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(ShowEmptyState))]
    public partial bool IsScanning { get; set; }

    [ObservableProperty]
    public partial bool IsConnecting { get; set; }

    /// <summary>
    /// True when not currently scanning and no devices were found.
    /// </summary>
    public bool ShowEmptyState => !IsScanning && Devices.Count == 0;

    public ObservableCollection<BluetoothDevice> Devices { get; } = new();

    public DeviceSelectionViewModel(IBluetoothService bluetoothService)
    {
        _bluetoothService = bluetoothService;
    }

    public override Task OnPageLoaded() => ScanAsync(CancellationToken.None);

    [RelayCommand]
    private async Task ScanAsync(CancellationToken cancellationToken)
    {
        try
        {
            IsScanning = true;
            Devices.Clear();

            var devices = await _bluetoothService.ScanForDevicesAsync(cancellationToken);

            foreach (var device in devices)
            {
                Devices.Add(device);
            }
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlertAsync("Scan Error", ex.Message, "OK");
        }
        finally
        {
            IsScanning = false;
            OnPropertyChanged(nameof(ShowEmptyState));
        }
    }

    [RelayCommand]
    private async Task SelectDeviceAsync(BluetoothDevice device)
    {
        try
        {
            IsConnecting = true;
            await _bluetoothService.ConnectAsync(device);
            SelectedDevice = device;
            await Shell.Current.GoToAsync("colorpicker");
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlertAsync("Connection Error", ex.Message, "OK");
        }
        finally
        {
            IsConnecting = false;
        }
    }
}
