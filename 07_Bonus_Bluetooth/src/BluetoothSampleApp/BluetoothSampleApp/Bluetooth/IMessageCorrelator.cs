using BluetoothSampleApp.Messages;

namespace BluetoothSampleApp.Bluetooth;

/// <summary>
/// Tracks pending request/response correlations for BLE messages.
/// Maps outgoing request IDs to completion sources so that incoming
/// responses can be matched to their original requests.
/// </summary>
public interface IMessageCorrelator
{
    /// <summary>
    /// Registers a pending request and returns a <see cref="TaskCompletionSource{Message}"/>
    /// that will be completed when the correlated response arrives.
    /// </summary>
    TaskCompletionSource<Message> RegisterRequest(Guid requestId);

    /// <summary>
    /// Attempts to complete a pending request with the given response message.
    /// Returns true if a matching request was found and completed.
    /// </summary>
    bool TryCompleteRequest(Guid requestId, Message response);

    /// <summary>
    /// Removes a pending request registration (e.g., on cancellation or failure).
    /// </summary>
    void RemoveRequest(Guid requestId);

    /// <summary>
    /// Fails all pending requests with the given exception (e.g., on disconnect).
    /// </summary>
    void FailAll(Exception exception);
}

