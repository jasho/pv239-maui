using CookBook.Mobile.Core.Factories;
using CookBook.Mobile.Core.Repositories;
using CookBook.Mobile.Core.Services;
using CookBook.Mobile.Core.ViewModels;
using CookBook.Mobile.Core.ViewModels.Ingredients;
using CookBook.Mobile.Core.ViewModels.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CookBook.Mobile.Core.Installers
{
    public class CoreInstaller
    {
        public void Install(IServiceCollection serviceCollection, IDependencyInjectionService dependencyInjectionService)
        {
            serviceCollection.AddSingleton(dependencyInjectionService);

            InstallFactories(serviceCollection);
            InstallRepositories(serviceCollection);
            InstallViewModels(serviceCollection);
        }

        private void InstallRepositories(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IIngredientRepository, IngredientRepository>();
        }

        private void InstallFactories(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<ICommandFactory, CommandFactory>();
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