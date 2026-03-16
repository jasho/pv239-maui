using PV239_07_Bonus_Bluetooth.ViewModels;

namespace PV239_07_Bonus_Bluetooth.Pages;

public partial class DeviceSelectionPage
{
    public DeviceSelectionPage(DeviceSelectionViewModel  viewModel)
    {
        InitializeComponent();
        BindingContext  = viewModel;
    }
}