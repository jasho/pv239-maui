namespace BluetoothSampleApp.Models;

public record ColorModel
{
    /// <summary>
    /// The red component of the color (0-255)
    /// </summary>
    public byte Red { get; set; }
    
    /// <summary>
    /// The green component of the color (0-255)
    /// </summary>
    public byte Green { get; set; }
    
    /// <summary>
    /// The blue component of the color (0-255)
    /// </summary>
    public byte Blue { get; set; }
    
    /// <summary>
    /// The brightness of the color (0.0-1.0)
    /// </summary>
    public double Brightness { get; set; }
}