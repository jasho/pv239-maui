using CookBook.Mobile.Core.Services;
using CookBook.Mobile.Core.ViewModels.Interfaces;
using CookBook.Mobile.Exceptions;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CookBook.Mobile.Services
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

        public async Task PopAsync(bool animated)
        {
            await navigation.PopAsync(animated);
        }

        public async Task PopToRootAsync(bool animated)
        {
            await navigation.PopToRootAsync(animated);
        }

        public async Task PushAsync<TViewModel>(bool animated, bool clearHistory)
            where TViewModel : class, IViewModel
        {
            var view = ResolveView<TViewModel>();
            if (clearHistory)
            {
                await ReplaceRootAsync(view, animated);
            }
            else
            {
                await navigation.PushAsync(view, animated);
            }
        }

        public async Task PushAsync<TViewModel, TViewModelParameter>(TViewModelParameter? viewModelParameter, bool animated, bool clearHistory)
            where TViewModel : class, IViewModel<TViewModelParameter>
        {
            var view = ResolveView<TViewModel, TViewModelParameter>(viewModelParameter);
            if (clearHistory)
            {
                await ReplaceRootAsync(view, animated);
            }
            else
            {
                await navigation.PushAsync(view, animated);
            }
        }

        private async Task ReplaceRootAsync(Page view, bool animated)
        {
            if (navigation.NavigationStack.Any())
            {
                var root = navigation.NavigationStack.First();
                navigation.InsertPageBefore(view, root);
                await navigation.PopToRootAsync(animated);
            }
            else
            {
                await navigation.PushAsync(view, animated);
            }
        }

        private Page ResolveView<TViewModel>()
            where TViewModel : class, IViewModel
        {
            Page view;
            try
            {
                view = mvvmLocatorService.ResolveView<TViewModel>()!;
                return view;
            }
            catch (ViewNotLocatedException)
            {
                // Handle exception
                throw;
            }

            return view;
        }

        private Page ResolveView<TViewModel, TViewModelParameter>(TViewModelParameter? viewModelParameter)
            where TViewModel : class, IViewModel<TViewModelParameter>
        {
            Page view;
            try
            {
                view = mvvmLocatorService.ResolveView<TViewModel, TViewModelParameter>(viewModelParameter)!;
                return view;
            }
            catch (ViewNotLocatedException)
            {
                // Handle exception
                throw;
            }

            return view;
        }
    }
}