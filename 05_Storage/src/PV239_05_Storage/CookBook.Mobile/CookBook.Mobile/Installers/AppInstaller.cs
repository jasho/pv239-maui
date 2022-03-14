using CookBook.Mobile.Core.Services;
using CookBook.Mobile.Services;
using CookBook.Mobile.Views;
using Microsoft.Extensions.DependencyInjection;
using Xamarin.Forms;

namespace CookBook.Mobile.Installers
{
    public class AppInstaller
    {
        public void Install(IServiceCollection serviceCollection, Application application, INavigation navigation)
        {
            serviceCollection.AddSingleton(application);
            serviceCollection.AddSingleton(navigation);

            InstallServices(serviceCollection);
            InstallViews(serviceCollection);
        }

        private void InstallServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IMvvmLocatorService, MvvmLocatorService>();
            serviceCollection.AddSingleton<INavigationService, NavigationService>();
            serviceCollection.AddSingleton<IPreferencesService, PreferencesService>();
            serviceCollection.AddSingleton<ISecureStorageService, SecureStorageService>();
        }

        private void InstallViews(IServiceCollection serviceCollection)
        {
            serviceCollection.Scan(selector => selector
                .FromAssemblyOf<AppInstaller>()
                .AddClasses(filter => filter.AssignableTo<ContentPageBase>())
                .AsSelf()
                .WithTransientLifetime());
        }
    }
}