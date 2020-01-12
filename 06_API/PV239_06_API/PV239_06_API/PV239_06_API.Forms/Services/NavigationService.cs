using System;
using System.Threading.Tasks;
using PV239_06_API.Core.Services.Interfaces;
using PV239_06_API.Core.ViewModels.Base;
using PV239_06_API.Forms.Services.Interfaces;
using Xamarin.Forms;

namespace PV239_06_API.Forms.Services
{
    public class NavigationService : INavigationService
    {
        private readonly INavigation navigation;
        private readonly IMvvmLocatorService mvvmLocatorService;

        public NavigationService(INavigation navigation, IMvvmLocatorService mvvmLocatorService)
        {
            this.navigation = navigation;
            this.mvvmLocatorService = mvvmLocatorService;
        }

        public async Task PopAsync(bool animated = false)
        {
            await navigation.PopAsync(animated);
        }

        public async Task PopToRootAsync(bool animated = false)
        {
            await navigation.PopToRootAsync(animated);
        }

        public async Task PushAsync<TViewModel>(TViewModel viewModel = default, bool animated = false, bool clearHistory = false)
            where TViewModel : class, IViewModel
        {
            try
            {
                var view = mvvmLocatorService.ResolveView(viewModel);
                await navigation.PushAsync(view, animated);
            }
            catch (Exception e)
            {
                // ignored
            }
        }

        public async Task PushAsync<TViewModel, TViewModelParameter>(TViewModelParameter viewModelParameter = default, TViewModel viewModel = default, bool animated = default, bool clearHistory = default)
            where TViewModel : class, IViewModel<TViewModelParameter>
        {
            try
            {
                var view = mvvmLocatorService.ResolveView(viewModel, viewModelParameter);
                await navigation.PushAsync(view, animated);
            }
            catch (Exception e)
            {
                // ignored
            }
        }
    }
}
