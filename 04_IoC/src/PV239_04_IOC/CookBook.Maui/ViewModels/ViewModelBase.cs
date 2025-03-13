using CommunityToolkit.Mvvm.ComponentModel;

namespace CookBook.Maui.ViewModels;

public abstract class ViewModelBase : ObservableObject
{
    public virtual Task OnAppearingAsync()
        => Task.CompletedTask;
}
