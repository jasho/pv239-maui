using System.Text;
using System.Text.Json;
using BluetoothSampleApp.Messages;

namespace BluetoothSampleApp.Bluetooth;

/// <summary>
/// JSON-based implementation of <see cref="IMessageSerializer"/>.
/// Converts messages to/from UTF-8 JSON byte arrays.
/// </summary>
public class JsonMessageSerializer : IMessageSerializer
{
    private readonly JsonSerializerOptions _options = new() { PropertyNameCaseInsensitive = true };

    public byte[] Serialize(Message message)
    {
        var json = JsonSerializer.Serialize(message, _options);
        return Encoding.UTF8.GetBytes(json);
    }

    public Message? Deserialize(byte[] data)
    {
        if (data.Length == 0)
        {
            return null;
        }

        try
        {
            var json = Encoding.UTF8.GetString(data);
            return JsonSerializer.Deserialize<Message>(json, _options);
        }
        catch (JsonException)
        {
            return null;
        }
    }
}


