using Microsoft.Extensions.DependencyInjection;
using PV239_05_Storage.Core.Installers;
using PV239_05_Storage.Core.Services;
using PV239_05_Storage.Core.Services.Interfaces;
using PV239_05_Storage.Core.ViewModels;
using PV239_05_Storage.Forms.Installers;
using System.Globalization;
using System.Threading;
using Xamarin.Forms;

namespace PV239_05_Storage.Forms
{
    public partial class App
    {
        public IDependencyInjectionService DependencyInjectionService { get; }
        public App()
        {
            InitializeComponent();
            DependencyInjectionService = new DependencyInjectionService();

            var navigationPage = new NavigationPage();
            RegisterDependencies(DependencyInjectionService, navigationPage.Navigation);
            ApplySettings(DependencyInjectionService);

            var navigationService = DependencyInjectionService.Resolve<INavigationService>();
            navigationService.PushAsync<TodoListViewModel>();
            MainPage = navigationPage;
        }

        protected override async void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override async void OnResume()
        {
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

        private void ApplySettings(IDependencyInjectionService dependencyInjectionService)
        {
            var secureStorageService = dependencyInjectionService.Resolve<ISecureStorageService>();
            var language = secureStorageService.GetAsync("Language").GetAwaiter().GetResult();
            if (language != null)
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo(language);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
            }
        }
    }
}
