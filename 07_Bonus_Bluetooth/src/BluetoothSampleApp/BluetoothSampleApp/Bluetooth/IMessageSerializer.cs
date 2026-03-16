using BluetoothSampleApp.Messages;

namespace BluetoothSampleApp.Bluetooth;

/// <summary>
/// Responsible for serializing and deserializing BLE messages.
/// </summary>
public interface IMessageSerializer
{
    /// <summary>
    /// Serializes a message to a byte array for BLE transmission.
    /// </summary>
    byte[] Serialize(Message message);

    /// <summary>
    /// Deserializes a byte array received from BLE into a message.
    /// Returns null if the data is malformed.
    /// </summary>
    Message? Deserialize(byte[] data);
}

