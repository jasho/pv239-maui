using System.Threading.Tasks;
using PV239_05_Storage.Core.ViewModels.Base;

namespace PV239_05_Storage.Core.Services.Interfaces
{
    public interface INavigationService : ISingletonService
    {
        Task PushAsync<TViewModel>(TViewModel viewModel = default, bool animated = default, bool clearHistory = default)
            where TViewModel : class, IViewModel;
        Task PopAsync(bool animated = default);
        Task PopToRootAsync(bool animated = default);

        Task PushAsync<TViewModel, TViewModelParameter>(TViewModelParameter viewModelParameter = default, TViewModel viewModel = default, bool animated = default, bool clearHistory = default)
            where TViewModel : class, IViewModel<TViewModelParameter>;
    }
}