using CookBook.Mobile.Core.ViewModels;
using System.Threading.Tasks;

namespace CookBook.Mobile.Core.Services.Interfaces
{
    public interface INavigationService
    {
        Task PushAsync<TViewModel>(bool animated = default, bool clearHistory = default)
            where TViewModel : class, IViewModel;

        Task PushAsync<TViewModel, TViewModelParameter>(
            TViewModelParameter? viewModelParameter = default, bool animated = default, bool clearHistory = default)
            where TViewModel : class, IViewModel<TViewModelParameter>;

        Task PopAsync(bool animated = default);
        Task PopToRootAsync(bool animated = default);
    }
}