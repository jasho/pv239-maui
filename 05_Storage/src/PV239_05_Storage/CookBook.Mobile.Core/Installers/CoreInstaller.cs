using CookBook.Mobile.Core.Factories;
using CookBook.Mobile.Core.Repositories;
using CookBook.Mobile.Core.Services;
using CookBook.Mobile.Core.ViewModels.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CookBook.Mobile.Core.Installers
{
    public class CoreInstaller
    {
        public void Install(IServiceCollection serviceCollection, IDependencyInjectionService dependencyInjectionService)
        {
            serviceCollection.AddSingleton(dependencyInjectionService);
            serviceCollection.AddAutoMapper(typeof(CoreInstaller));

            InstallFactories(serviceCollection);
            InstallRepositories(serviceCollection);
            InstallServices(serviceCollection);
            InstallViewModels(serviceCollection);
        }

        private void InstallFactories(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<ICommandFactory, CommandFactory>();
        }

        private void InstallRepositories(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IIngredientRepository, IngredientRepository>();
        }

        private void InstallServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IDatabaseService, DatabaseService>();
        }

        private void InstallViewModels(IServiceCollection serviceCollection)
        {
            serviceCollection.Scan(selector => selector
                .FromAssemblyOf<CoreInstaller>()
                .AddClasses(filter => filter.AssignableTo<IViewModel>())
                .AsSelf()
                .WithTransientLifetime());
        }
    }
}