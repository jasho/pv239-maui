using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using PV239_07_Bonus_Bluetooth.Bluetooth;
using PV239_07_Bonus_Bluetooth.Pages;
using PV239_07_Bonus_Bluetooth.ViewModels;

namespace PV239_07_Bonus_Bluetooth;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        builder.Services.AddSingleton<IBluetoothService, BluetoothService>();
        
        builder.Services.AddTransient<ChatViewModel>();
        builder.Services.AddTransient<DeviceSelectionViewModel>();

        builder.Services.AddTransient<ChatPage>();
        builder.Services.AddTransient<ChatViewModel>();

        return builder.Build();
    }
}