using CommunityToolkit.Mvvm.ComponentModel;

namespace BluetoothSampleApp.ViewModels;

public abstract class BaseViewModel : ObservableObject
{
    /// <summary>
    /// Called when the page associated with this view model appears.
    /// Override to perform initialization such as loading data.
    /// </summary>
    public virtual Task OnPageLoaded() => Task.CompletedTask;

    /// <summary>
    /// Called when the page associated with this view model disappears.
    /// Override to perform cleanup such as disconnecting from devices.
    /// </summary>
    public virtual Task OnPageUnloaded() => Task.CompletedTask;
}
