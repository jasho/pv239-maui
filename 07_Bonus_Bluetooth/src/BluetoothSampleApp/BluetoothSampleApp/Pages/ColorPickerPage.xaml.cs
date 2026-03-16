using BluetoothSampleApp.ViewModels;

namespace BluetoothSampleApp.Pages;

public partial class ColorPickerPage : PageBase
{
    public ColorPickerPage(ColorPickerViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
