using BluetoothSampleApp.Models;

namespace BluetoothSampleApp.Messages;

public record ColorUpdated
{
    public required ColorModel Color { get; set; }
}