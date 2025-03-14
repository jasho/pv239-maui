using CommunityToolkit.Mvvm.ComponentModel;

namespace CookBook.Maui.ViewModels;

public abstract class ViewModelBase : ObservableObject
{
    protected bool ForceDataRefresh = true;

    public async Task OnAppearingAsync()
    {
        if (ForceDataRefresh)
        {
            await LoadDataAsync();
        }
    }

    protected virtual Task LoadDataAsync()
        => Task.CompletedTask;
}
