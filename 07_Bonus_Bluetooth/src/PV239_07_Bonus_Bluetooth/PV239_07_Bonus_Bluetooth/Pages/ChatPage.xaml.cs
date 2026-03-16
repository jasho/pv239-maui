using PV239_07_Bonus_Bluetooth.ViewModels;

namespace PV239_07_Bonus_Bluetooth.Pages;

public partial class ChatPage
{
    public ChatPage(ChatViewModel  viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}