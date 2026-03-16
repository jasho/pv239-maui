using BluetoothSampleApp.Models;

namespace BluetoothSampleApp.Messages;

public record SetColorRequest
{
    public required ColorModel Color { get; set; }
}