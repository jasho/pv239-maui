using System;
using CookBook.Mobile.Core.ViewModels;
using Xamarin.Forms;

namespace CookBook.Mobile.Services
{
    public interface IMvvmLocatorService
    {
        Page? ResolveView<TViewModel>(TViewModel? viewModel = null)
            where TViewModel : class, IViewModel;

        Page? ResolveView<TViewModel, TViewModelParameter>(TViewModel? viewModel = null,
            TViewModelParameter? viewModelParameter = default)
            where TViewModel : class, IViewModel<TViewModelParameter>;

        Page? ResolveView(Type viewModelType);

        Type GetViewType<TViewModel>(TViewModel? viewModel = null)
            where TViewModel : class;
        Type GetViewType(Type viewModelType);
    }
}