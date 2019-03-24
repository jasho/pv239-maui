using System;
using PV239_05_Storage.Core.Services.Interfaces;
using PV239_05_Storage.Forms.Services.Interfaces;
using PV239_05_Storage.Forms.Views;
using Xamarin.Forms;

namespace PV239_05_Storage.Forms.Services
{
    public class MvvmLocatorService : IMvvmLocatorService
    {
        private readonly IDependencyInjectionService dependencyInjectionService;

        public MvvmLocatorService(IDependencyInjectionService dependencyInjectionService)
        {
            this.dependencyInjectionService = dependencyInjectionService;
        }

        public Page ResolveView<TViewModel>(TViewModel viewModel = default)
        {
            var viewType = GetViewType(viewModel);
            return GetView(viewType);
        }

        private Type GetViewType<TViewModel>(TViewModel viewModel)
        {
            var viewModelType = viewModel?.GetType() ?? typeof(TViewModel);
            var viewTypeName = viewModelType
                .AssemblyQualifiedName
                .Replace(viewModelType.Assembly.GetName().Name, typeof(ViewBase).Assembly.GetName().Name)
                .Replace("ViewModel", "View");

            var viewType = Type.GetType(viewTypeName);
            if (viewType != null)
            {
                return viewType;
            }
            else
            {
                throw new Exception();
            }
        }

        private Page GetView(Type viewType)
        {
            return dependencyInjectionService.Resolve(viewType) as Page;
        }
    }
}