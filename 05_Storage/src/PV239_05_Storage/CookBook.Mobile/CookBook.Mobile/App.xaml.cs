using CookBook.Mobile.Core;
using CookBook.Mobile.Core.Entities;
using CookBook.Mobile.Core.Installers;
using CookBook.Mobile.Core.Services;
using CookBook.Mobile.Core.ViewModels;
using CookBook.Mobile.Installers;
using Microsoft.Extensions.DependencyInjection;
using System;
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

            var databaseService = dependencyInjectionService.Resolve<IDatabaseService>();
            SetupDatabase(databaseService);

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

        private void SetupDatabase(IDatabaseService databaseService)
        {
            databaseService.CreateTableAsync<IngredientEntity>();

            databaseService.SetAsync(new IngredientEntity
            {
                Id = Guid.Empty,
                Name = "Vejce",
                Description = "Popis vajec",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/5e/Chicken_egg_2009-06-04.jpg/428px-Chicken_egg_2009-06-04.jpg"
            });

            databaseService.SetAsync(new IngredientEntity
            {
                Id = Guid.Empty,
                Name = "Cibule",
                Description = "Popis cibule",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/2/25/Onion_on_White.JPG/480px-Onion_on_White.JPG"
            });
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
