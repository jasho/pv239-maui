namespace BluetoothSampleApp.Messages;

/// <summary>
/// Represents a message sent between the app and the Bluetooth device.
/// </summary>
public record Message
{
    /// <summary>
    /// A unique identifier for the message, used for tracking and correlating requests and responses.
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();
    
    /// <summary>
    /// If this message is a response to a previous request, this property holds the Id of the original request.
    /// </summary>
    public Guid? ResponseToId { get; set; }
    
    /// <summary>
    /// The timestamp when the message was created
    /// </summary>
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    
    /// <summary>
    /// The type of the message, used to determine how to process it. For example, "SetColorRequest", "SetColorResponse", "Error", etc.
    /// </summary>
    public required string Type { get; set; }
    
    /// <summary>
    /// The payload of the message.
    ///
    /// This is a JSON string that contains the actual data of the message,
    /// which can be deserialized into the appropriate request or response object based on the Type property.
    /// </summary>
    public required string Payload { get; set; }
}