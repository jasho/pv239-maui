using CookBook.Mobile.Core.Installers;
using CookBook.Mobile.Core.Services;
using CookBook.Mobile.Core.ViewModels;
using CookBook.Mobile.Installers;
using Microsoft.Extensions.DependencyInjection;
using Xamarin.Forms;

namespace CookBook.Mobile
{
    public partial class App
    {
        private readonly IDependencyInjectionService dependencyInjectionService;

        public App()
        {
            InitializeComponent();

            dependencyInjectionService = new DependencyInjectionService();
            var navigationPage = new NavigationPage();

            InstallDependencies(dependencyInjectionService, this, navigationPage.Navigation);

            var navigationService = dependencyInjectionService.Resolve<INavigationService>();
            navigationService.PushAsync<MainViewModel>();

            MainPage = navigationPage;
        }

        private void InstallDependencies(IDependencyInjectionService dependencyInjectionService, App application, INavigation navigation)
        {
            var serviceCollection = new ServiceCollection();

            new CoreInstaller().Install(serviceCollection, dependencyInjectionService);
            new AppInstaller().Install(serviceCollection, application, navigation);

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
