using CookBook.Mobile.ViewModels.Settings;

namespace CookBook.Mobile.Views.Settings;

public partial class SettingsView
{
    public SettingsView(SettingsViewModel settingsViewModel)
        : base(settingsViewModel)
    {
        InitializeComponent();
    }
}