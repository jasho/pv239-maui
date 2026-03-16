using BluetoothSampleApp.Pages;

namespace BluetoothSampleApp;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute("colorpicker", typeof(ColorPickerPage));
    }
}