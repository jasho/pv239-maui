using CommunityToolkit.Mvvm.ComponentModel;

namespace CookBook.Mobile.ViewModels;

public class ViewModelBase : ObservableObject
{
    public virtual Task OnAppearingAsync()
    {
        return Task.CompletedTask;
    }
}