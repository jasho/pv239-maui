using BluetoothSampleApp.Messages;
using BluetoothSampleApp.Models;
using Plugin.BLE.Abstractions.EventArgs;
using Polly;
using Polly.Retry;

namespace BluetoothSampleApp.Bluetooth;

/// <summary>
/// Facade that composes <see cref="IDeviceScanner"/>, <see cref="IDeviceConnector"/>,
/// <see cref="IMessageSerializer"/>, and <see cref="IMessageCorrelator"/> to provide
/// a high-level BLE communication API.
/// </summary>
public class BluetoothService : IBluetoothService, IDisposable
{
    private static readonly TimeSpan SendTimeout = TimeSpan.FromSeconds(3);
    private const int MaxRetries = 2;

    private readonly IDeviceScanner _scanner;
    private readonly IDeviceConnector _connector;
    private readonly IMessageSerializer _serializer;
    private readonly IMessageCorrelator _correlator;
    private readonly ResiliencePipeline<Message> _sendPipeline;

    /// <inheritdoc />
    public event EventHandler<Message>? NotificationReceived;

    /// <inheritdoc />
    public event EventHandler? Disconnected;

    /// <inheritdoc />
    public bool IsConnected => _connector.IsConnected;

    public BluetoothService(
        IDeviceScanner scanner,
        IDeviceConnector connector,
        IMessageSerializer serializer,
        IMessageCorrelator correlator)
    {
        _scanner = scanner;
        _connector = connector;
        _serializer = serializer;
        _correlator = correlator;

        _connector.ConnectionLost += OnConnectionLost;

        _sendPipeline = new ResiliencePipelineBuilder<Message>()
            .AddRetry(new RetryStrategyOptions<Message>
            {
                MaxRetryAttempts = MaxRetries,
                BackoffType = DelayBackoffType.Exponential,
                Delay = TimeSpan.FromMilliseconds(500),
                ShouldHandle = new PredicateBuilder<Message>()
                    .Handle<TimeoutException>()
                    .Handle<IOException>()
                    .Handle<Exception>(ex => ex.Message.Contains("characteristic", StringComparison.OrdinalIgnoreCase)),
            })
            .AddTimeout(SendTimeout)
            .Build();
    }

    /// <inheritdoc />
    public Task<IReadOnlyList<BluetoothDevice>> ScanForDevicesAsync(CancellationToken cancellationToken = default)
        => _scanner.ScanAsync(cancellationToken);

    /// <inheritdoc />
    public async Task ConnectAsync(BluetoothDevice device, CancellationToken cancellationToken = default)
    {
        await _connector.ConnectAsync(device, cancellationToken);

        // Subscribe to notifications from the RX characteristic
        if (_connector.RxCharacteristic is not null)
        {
            _connector.RxCharacteristic.ValueUpdated += OnCharacteristicValueUpdated;
            await _connector.RxCharacteristic.StartUpdatesAsync(cancellationToken);
        }
    }

    /// <inheritdoc />
    public async Task DisconnectAsync(CancellationToken cancellationToken = default)
    {
        if (_connector.RxCharacteristic is not null)
        {
            _connector.RxCharacteristic.ValueUpdated -= OnCharacteristicValueUpdated;

            try
            {
                await _connector.RxCharacteristic.StopUpdatesAsync(cancellationToken);
            }
            catch
            {
                // Best-effort cleanup
            }
        }

        await _connector.DisconnectAsync(cancellationToken);

        // Fail all pending requests since we're disconnecting
        _correlator.FailAll(new IOException("Device disconnected."));
    }

    /// <inheritdoc />
    public async Task<Message> SendMessageAsync(Message message, CancellationToken cancellationToken = default)
    {
        if (!IsConnected || _connector.TxCharacteristic is null)
        {
            throw new InvalidOperationException("Not connected to a device.");
        }

        return await _sendPipeline.ExecuteAsync(
            async ct => await SendAndWaitForResponseAsync(message, ct),
            cancellationToken);
    }

    private async Task<Message> SendAndWaitForResponseAsync(Message message, CancellationToken cancellationToken)
    {
        var tcs = _correlator.RegisterRequest(message.Id);

        await using var registration = cancellationToken.Register(() =>
        {
            _correlator.RemoveRequest(message.Id);
            tcs.TrySetCanceled(cancellationToken);
        });

        try
        {
            var bytes = _serializer.Serialize(message);
            await _connector.TxCharacteristic!.WriteAsync(bytes, cancellationToken);
            return await tcs.Task;
        }
        catch
        {
            _correlator.RemoveRequest(message.Id);
            throw;
        }
    }

    private void OnCharacteristicValueUpdated(object? sender, CharacteristicUpdatedEventArgs args)
    {
        try
        {
            var bytes = args.Characteristic.Value;
            if (bytes is null || bytes.Length == 0)
            {
                return;
            }

            var message = _serializer.Deserialize(bytes);
            if (message is null)
            {
                return;
            }

            // Check if this is a response to a pending request
            if (message.ResponseToId.HasValue &&
                _correlator.TryCompleteRequest(message.ResponseToId.Value, message))
            {
                return;
            }

            // This is an unsolicited notification
            NotificationReceived?.Invoke(this, message);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error processing received message: {ex}");
        }
    }

    private void OnConnectionLost(object? sender, EventArgs args)
    {
        _correlator.FailAll(new IOException("Device connection lost."));
        Disconnected?.Invoke(this, EventArgs.Empty);
    }

    public void Dispose()
    {
        _connector.ConnectionLost -= OnConnectionLost;
        DisconnectAsync().GetAwaiter().GetResult();
        GC.SuppressFinalize(this);
    }
}