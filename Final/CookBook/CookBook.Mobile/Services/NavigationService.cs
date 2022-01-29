using CookBook.Mobile.Core.Services.Interfaces;
using CookBook.Mobile.Core.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;
using CookBook.Mobile.Exceptions;
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
        public async Task PushAsync(Type viewModelType, bool animated, bool clearHistory)
        {
            var view = ResolveView(viewModelType);
            if (clearHistory)
            {
                await ReplaceRootAsync(view, animated);
            }
            else
            {
                await navigation.PushAsync(view, animated);
            }
        }

        public async Task PushAsync<TViewModel>(TViewModel? viewModel, bool animated, bool clearHistory)
            where TViewModel : class, IViewModel
        {
            var view = ResolveView(viewModel);
            if (clearHistory)
            {
                await ReplaceRootAsync(view, animated);
            }
            else
            {
                await navigation.PushAsync(view, animated);
            }
        }

        public async Task PushAsync<TViewModel, TViewModelParameter>(TViewModel? viewModel,
            TViewModelParameter? viewModelParameter, bool animated, bool clearHistory)
            where TViewModel : class, IViewModel<TViewModelParameter>
        {
            var view = ResolveView(viewModel, viewModelParameter);
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

        private Page ResolveView(Type viewModelType)
        {
            Page view;
            try
            {
                view = mvvmLocatorService.ResolveView(viewModelType)!;
                return view;
            }
            catch (ViewNotLocatedException)
            {
                view = mvvmLocatorService.ResolveView<ErrorViewModel>()!;
            }

            return view;
        }

        private Page ResolveView<TViewModel>(TViewModel? viewModel)
            where TViewModel : class, IViewModel
        {
            Page view;
            try
            {
                view = mvvmLocatorService.ResolveView(viewModel)!;
                return view;
            }
            catch (ViewNotLocatedException)
            {
                view = mvvmLocatorService.ResolveView<ErrorViewModel>()!;
            }

            return view;
        }

        private Page ResolveView<TViewModel, TViewModelParameter>(TViewModel? viewModel, TViewModelParameter? viewModelParameter)
            where TViewModel : class, IViewModel<TViewModelParameter>
        {
            Page view;
            try
            {
                view = mvvmLocatorService.ResolveView(viewModel, viewModelParameter)!;
                return view;
            }
            catch (ViewNotLocatedException)
            {
                view = mvvmLocatorService.ResolveView<ErrorViewModel>()!;
            }

            return view;
        }
    }
}