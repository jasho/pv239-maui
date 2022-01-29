using CookBook.Mobile.Core.ViewModels;
using System;
using System.Threading.Tasks;

namespace CookBook.Mobile.Core.Services.Interfaces
{
    public interface INavigationService
    {
        Task PushAsync(Type viewModelType, bool animated = false, bool clearHistory = false);
        Task PushAsync<TViewModel>(TViewModel? viewModel = default, bool animated = default, bool clearHistory = default)
            where TViewModel : class, IViewModel;

        Task PushAsync<TViewModel, TViewModelParameter>(
            TViewModel? viewModel = default,
            TViewModelParameter? viewModelParameter = default, bool animated = default, bool clearHistory = default)
            where TViewModel : class, IViewModel<TViewModelParameter>;

        Task PopAsync(bool animated = default);
        Task PopToRootAsync(bool animated = default);
    }
}