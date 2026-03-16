using System.Text.Json;
using BluetoothSampleApp.Bluetooth;
using BluetoothSampleApp.Messages;
using BluetoothSampleApp.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BluetoothSampleApp.ViewModels;

public partial class ColorPickerViewModel : BaseViewModel, IDisposable
{
    private readonly IBluetoothService _bluetoothService;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(PreviewColor))]
    public partial double Red { get; set; } = 255;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(PreviewColor))]
    public partial double Green { get; set; } = 0;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(PreviewColor))]
    public partial double Blue { get; set; } = 0;

    /// <summary>0.0–1.0, displayed as 0%–100% via StringFormat '{0:P0}'</summary>
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(PreviewColor))]
    public partial double Brightness { get; set; } = 1.0;

    [ObservableProperty]
    public partial bool IsSending { get; set; }

    public Color PreviewColor => new Color(
        (float)(Red / 255.0 * Brightness),
        (float)(Green / 255.0 * Brightness),
        (float)(Blue / 255.0 * Brightness));

    public ColorPickerViewModel(IBluetoothService bluetoothService)
    {
        _bluetoothService = bluetoothService;
        _bluetoothService.NotificationReceived += OnNotificationReceived;
        _bluetoothService.Disconnected += OnDisconnected;
    }

    [RelayCommand]
    private async Task SendColorAsync(CancellationToken cancellationToken)
    {
        try
        {
            IsSending = true;

            var colorPayload = new SetColorRequest
            {
                Color = new ColorModel
                {
                    Red = (byte)Red,
                    Green = (byte)Green,
                    Blue = (byte)Blue,
                    Brightness = Brightness,
                },
            };

            var message = new Message
            {
                Type = nameof(SetColorRequest),
                Payload = JsonSerializer.Serialize(colorPayload),
            };

            await _bluetoothService.SendMessageAsync(message, cancellationToken);
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlertAsync("Send Error", ex.Message, "OK");
        }
        finally
        {
            IsSending = false;
        }
    }

    [RelayCommand]
    private async Task GetColorAsync(CancellationToken cancellationToken)
    {
        try
        {
            IsSending = true;

            var message = new Message
            {
                Type = nameof(GetColor),
                Payload = JsonSerializer.Serialize(new GetColor()),
            };

            var response = await _bluetoothService.SendMessageAsync(message, cancellationToken);
            ApplyColorFromPayload(response.Payload);
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlertAsync("Get Color Error", ex.Message, "OK");
        }
        finally
        {
            IsSending = false;
        }
    }

    [RelayCommand]
    private async Task DisconnectAsync()
    {
        await Shell.Current.GoToAsync("..");
    }

    public override Task OnPageLoaded()
        => GetColorAsync(CancellationToken.None);

    public override async Task OnPageUnloaded()
    {
        try
        {
            await _bluetoothService.DisconnectAsync();
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error disconnecting: {ex.Message}");
        }
    }

    private void OnNotificationReceived(object? sender, Message message)
    {
        if (message.Type == nameof(ColorUpdated))
        {
            MainThread.BeginInvokeOnMainThread(() => ApplyColorFromPayload(message.Payload));
        }
    }

    private void OnDisconnected(object? sender, EventArgs args)
    {
        MainThread.BeginInvokeOnMainThread(async () =>
        {
            await Shell.Current.DisplayAlertAsync("Connection Lost", "The device has been disconnected.", "OK");
            await Shell.Current.GoToAsync("..");
        });
    }

    private void ApplyColorFromPayload(string payload)
    {
        var colorUpdate = JsonSerializer.Deserialize<ColorUpdated>(payload, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        if (colorUpdate?.Color is not null)
        {
            Red = colorUpdate.Color.Red;
            Green = colorUpdate.Color.Green;
            Blue = colorUpdate.Color.Blue;
            Brightness = colorUpdate.Color.Brightness;
        }
    }

    public void Dispose()
    {
        _bluetoothService.NotificationReceived -= OnNotificationReceived;
        _bluetoothService.Disconnected -= OnDisconnected;
        GC.SuppressFinalize(this);
    }
}
