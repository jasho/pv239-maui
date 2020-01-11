using Microsoft.Extensions.DependencyInjection;
using PV239_03_MVVM.Core.Installers;
using PV239_03_MVVM.Core.Services;
using PV239_03_MVVM.Core.Services.Interfaces;
using PV239_03_MVVM.Core.ViewModels;
using PV239_03_MVVM.Forms.Installers;
using Xamarin.Forms;

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

            MainPage = navigationPage;
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
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
