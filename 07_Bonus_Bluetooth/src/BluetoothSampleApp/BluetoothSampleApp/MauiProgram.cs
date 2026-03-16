﻿using BluetoothSampleApp.Bluetooth;
 using Microsoft.Extensions.Logging;
using BluetoothSampleApp.Pages;
using BluetoothSampleApp.ViewModels;

namespace BluetoothSampleApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.AddSingleton<IDeviceScanner, DeviceScanner>();
        builder.Services.AddSingleton<IDeviceConnector, DeviceConnector>();
        builder.Services.AddSingleton<IMessageSerializer, JsonMessageSerializer>();
        builder.Services.AddSingleton<IMessageCorrelator, MessageCorrelator>();
        builder.Services.AddSingleton<IBluetoothService, BluetoothService>();
        builder.Services.AddTransient<DeviceSelectionViewModel>();
        builder.Services.AddTransient<DeviceSelectionPage>();
        builder.Services.AddTransient<ColorPickerViewModel>();
        builder.Services.AddTransient<ColorPickerPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}