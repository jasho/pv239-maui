using BluetoothSampleApp.ViewModels;

namespace BluetoothSampleApp.Pages;

public partial class DeviceSelectionPage : PageBase
{
    public DeviceSelectionPage(DeviceSelectionViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
