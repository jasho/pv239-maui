using System.Collections.Concurrent;
using BluetoothSampleApp.Messages;

namespace BluetoothSampleApp.Bluetooth;

/// <summary>
/// Thread-safe implementation of <see cref="IMessageCorrelator"/>.
/// Tracks pending BLE request/response correlations using a concurrent dictionary.
/// </summary>
public class MessageCorrelator : IMessageCorrelator
{
    private readonly ConcurrentDictionary<Guid, TaskCompletionSource<Message>> _pendingRequests = new();

    public TaskCompletionSource<Message> RegisterRequest(Guid requestId)
    {
        var tcs = new TaskCompletionSource<Message>(TaskCreationOptions.RunContinuationsAsynchronously);
        _pendingRequests[requestId] = tcs;
        return tcs;
    }

    public bool TryCompleteRequest(Guid requestId, Message response)
    {
        if (_pendingRequests.TryRemove(requestId, out var tcs))
        {
            return tcs.TrySetResult(response);
        }

        return false;
    }

    public void RemoveRequest(Guid requestId)
    {
        _pendingRequests.TryRemove(requestId, out _);
    }

    public void FailAll(Exception exception)
    {
        foreach (var kvp in _pendingRequests)
        {
            if (_pendingRequests.TryRemove(kvp.Key, out var tcs))
            {
                tcs.TrySetException(exception);
            }
        }
    }
}

