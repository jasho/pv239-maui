using CookBook.Mobile.Core;
using CookBook.Mobile.Core.Factories;
using CookBook.Mobile.Core.Installers;
using CookBook.Mobile.Core.Repositories;
using CookBook.Mobile.Core.Services;
using CookBook.Mobile.Core.ViewModels;
using CookBook.Mobile.Core.ViewModels.Ingredients;
using CookBook.Mobile.Installers;
using CookBook.Mobile.Services;
using CookBook.Mobile.Views.Ingredients;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
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

            var preferencesService = dependencyInjectionService.Resolve<IPreferencesService>();
            ApplyLanguagePreferences(preferencesService);

            var navigationService = dependencyInjectionService.Resolve<INavigationService>();
            navigationService.PushAsync<MainViewModel>();

            MainPage = navigationPage;
        }

        private void ApplyLanguagePreferences(IPreferencesService preferencesService)
        {
            var language = preferencesService.Get(PreferencesKeys.LanguageKey, "cs");

            CultureInfo.CurrentCulture = new CultureInfo(language);
            CultureInfo.CurrentUICulture = new CultureInfo(language);
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
