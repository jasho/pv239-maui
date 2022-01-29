using Autofac;
using CookBook.Mobile.Core.Services.Interfaces;
using CookBook.Mobile.Core.ViewModels;
using CookBook.Mobile.Exceptions;
using CookBook.Mobile.Views;
using System;
using Xamarin.Forms;

namespace CookBook.Mobile.Services
{
    public class MvvmLocatorService : IMvvmLocatorService
    {
        private readonly IDependencyInjectionService dependencyInjectionService;

        public MvvmLocatorService(IDependencyInjectionService dependencyInjectionService)
        {
            this.dependencyInjectionService = dependencyInjectionService;
        }

        public Page? ResolveView<TViewModel>()
            where TViewModel : class, IViewModel
        {
            var viewType = GetViewType<TViewModel>();
            return GetView<TViewModel, Page>(viewType);
        }

        public Page? ResolveView<TViewModel, TViewModelParameter>(TViewModelParameter? viewModelParameter = default)
            where TViewModel : class, IViewModel<TViewModelParameter>
        {
            var viewModelInstance = dependencyInjectionService.Resolve<TViewModel>(new TypedParameter(typeof(TViewModelParameter), viewModelParameter));
            viewModelInstance.SetViewModelParameter(viewModelParameter);
            var viewType = GetViewType(viewModelInstance);
            return GetView<TViewModel, Page>(viewType, viewModelInstance);
        }

        public Page? ResolveView(Type viewModelType)
        {
            var viewType = GetViewType(viewModelType);
            return dependencyInjectionService.Resolve(viewType) as Page;
        }

        private TView? ResolveGenericView<TView, TViewModel>(TViewModel? viewModel)
            where TView : class
            where TViewModel : class, IViewModel
        {
            var viewType = GetViewType(viewModel);
            return GetView<TViewModel, TView>(viewType, viewModel);
        }

        public Type GetViewType<TViewModel>(TViewModel? viewModel = null)
            where TViewModel : class
        {
            var viewModelType = viewModel?.GetType() ?? typeof(TViewModel);
            return GetViewType(viewModelType);
        }

        public Type GetViewType(Type viewModelType)
        {
            var viewTypeName = viewModelType
                .AssemblyQualifiedName
                ?.Replace(viewModelType.Assembly.GetName().Name, typeof(ContentPageBase).Assembly.GetName().Name)
                .Replace("ViewModel", "View");

            var viewType = Type.GetType(viewTypeName);
            if (viewType != null)
            {
                return viewType;
            }

            throw new ViewNotLocatedException($"View type '{viewTypeName}' for view model '{viewModelType.FullName}' was not located.");
        }

        private TView? GetView<TViewModel, TView>(Type viewType, TViewModel? viewModel = null)
            where TViewModel : class, IViewModel
            where TView : class
        {
            return viewModel is null
                ? dependencyInjectionService.Resolve(viewType) as TView
                : dependencyInjectionService.Resolve(viewType, new TypedParameter(typeof(TViewModel), viewModel)) as TView;
        }
    }
}