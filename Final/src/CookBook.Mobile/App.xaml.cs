using CookBook.Mobile.Core.Installers;
using CookBook.Mobile.Core.Services;
using CookBook.Mobile.Core.Services.Interfaces;
using CookBook.Mobile.Core.ViewModels;
using CookBook.Mobile.Installers;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Globalization;
using Xamarin.Forms;

namespace CookBook.Mobile
{
    public partial class App
    {
        private readonly IDependencyInjectionService dependencyInjectionService;

        public App(IEnumerable<IInstaller> installers)
        {
            InitializeComponent();

            dependencyInjectionService = new DependencyInjectionService();
            var navigationPage = new NavigationPage();

            InstallDependencies(dependencyInjectionService, navigationPage.Navigation, this, installers);

            CultureInfo.CurrentCulture = new CultureInfo("cs");
            CultureInfo.CurrentUICulture = new CultureInfo("cs");

            var navigationService = dependencyInjectionService.Resolve<INavigationService>();
            navigationService.PushAsync<MainViewModel>();

            MainPage = navigationPage;
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

        private void InstallDependencies(IDependencyInjectionService dependencyInjectionService, INavigation navigation, Application application, IEnumerable<IInstaller> installers)
        {
            var serviceCollection = new ServiceCollection();

            new CoreInstaller().Install(serviceCollection, dependencyInjectionService);
            new AppInstaller().Install(serviceCollection, application, navigation);

            foreach (var installer in installers)
            {
                installer.Install(serviceCollection);
            }

            dependencyInjectionService.Build(serviceCollection);
        }
    }
}
