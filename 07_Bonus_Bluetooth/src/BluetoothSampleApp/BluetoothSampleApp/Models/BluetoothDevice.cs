namespace BluetoothSampleApp.Models;

public record BluetoothDevice
{
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public int SignalStrength { get; set; }
}
