using PV239_06_API.Core.Services.Interfaces;
using PV239_06_API.Core.ViewModels.Base;
using Xamarin.Forms;

namespace PV239_06_API.Forms.Services.Interfaces
{
    public interface IMvvmLocatorService : ISingletonService
    {
        Page ResolveView<TViewModel>(TViewModel viewModel = default)
            where TViewModel : class, IViewModel;

        Page ResolveView<TViewModel, TViewModelParameter>(TViewModel viewModel = default, TViewModelParameter viewModelParameter = default)
            where TViewModel : class, IViewModel<TViewModelParameter>;
    }
}