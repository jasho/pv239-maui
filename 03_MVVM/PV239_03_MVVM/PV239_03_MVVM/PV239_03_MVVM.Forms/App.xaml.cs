using System;
using Microsoft.Extensions.DependencyInjection;
using PV239_03_MVVM.Core.Installers;
using PV239_03_MVVM.Core.Services;
using PV239_03_MVVM.Core.Services.Interfaces;
using PV239_03_MVVM.Core.ViewModels;
using PV239_03_MVVM.Forms.Installers;
using PV239_03_MVVM.Forms.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PV239_03_MVVM.Forms
{
    public partial class App : Application
    {
        public IDependencyInjectionService DependencyInjectionService { get; }
        public App()
        {
            InitializeComponent();

            DependencyInjectionService = new DependencyInjectionService();
            var navigationPage = new NavigationPage();

            RegisterDependencies(DependencyInjectionService, navigationPage.Navigation);
            var navigationService = DependencyInjectionService.Resolve<INavigationService>();
            navigationService.PushAsync<TodoListViewModel>();

            MainPage = new CalculatorView();
            //MainPage = navigationPage;
        }

        private void RegisterDependencies(IDependencyInjectionService dependencyInjectionService, INavigation navigation)
        {
            var serviceCollection = new ServiceCollection();
            var coreInstaller = new CoreInstaller();
            coreInstaller.Install(serviceCollection, dependencyInjectionService);

            var formsInstaller = new FormsInstaller();
            formsInstaller.Install(serviceCollection, navigation);

            dependencyInjectionService.Build(serviceCollection);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
