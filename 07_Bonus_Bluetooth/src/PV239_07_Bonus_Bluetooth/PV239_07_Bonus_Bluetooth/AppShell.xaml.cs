using PV239_07_Bonus_Bluetooth.Pages;

namespace PV239_07_Bonus_Bluetooth;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute("chat", typeof(ChatPage));
    }
}