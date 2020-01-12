using System.Globalization;
using System.Threading;
using Microsoft.Extensions.DependencyInjection;
using PV239_06_API.Core.Installers;
using PV239_06_API.Core.Mappings;
using PV239_06_API.Core.Services;
using PV239_06_API.Core.Services.Interfaces;
using PV239_06_API.Core.ViewModels;
using PV239_06_API.Forms.Installers;
using PV239_06_API.Forms.Views;
using Xamarin.Forms;

namespace PV239_06_API.Forms
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
            InitializeAutoMapper(DependencyInjectionService);
            ApplySettings(DependencyInjectionService);

            var navigationService = DependencyInjectionService.Resolve<INavigationService>();
            navigationService.PushAsync<TodoListViewModel>();

            MainPage = navigationPage;
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

        private void RegisterDependencies(IDependencyInjectionService dependencyInjectionService, INavigation navigation)
        {
            var serviceCollection = new ServiceCollection();
            var coreInstaller = new CoreInstaller();
            coreInstaller.Install(serviceCollection, dependencyInjectionService);

            var formsInstaller = new FormsInstaller();
            formsInstaller.Install(serviceCollection, navigation);

            dependencyInjectionService.Build(serviceCollection);
        }

        private void InitializeAutoMapper(IDependencyInjectionService dependencyInjectionService)
        {
            var mapperService = dependencyInjectionService.Resolve<IMapperService>();
            var mappings = dependencyInjectionService.ResolveAll<IMapping>();
            mapperService.Initialize(mappings);
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
