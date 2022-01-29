using CookBook.Mobile.Core.Factories;
using CookBook.Mobile.Core.Services.Interfaces;
using CookBook.Mobile.Core.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace CookBook.Mobile.Core.Installers
{
    public class CoreInstaller
    {
        public void Install(IServiceCollection serviceCollection, IDependencyInjectionService dependencyInjectionService)
        {
            serviceCollection.AddSingleton(dependencyInjectionService);

            InstallFactories(serviceCollection);
            InstallServices(serviceCollection);

            serviceCollection.Scan(selector => selector
                .FromAssemblyOf<CoreInstaller>()
                .AddClasses(filter => filter.AssignableTo<IViewModel>())
                    .AsSelf()
                    .WithTransientLifetime());

            serviceCollection.AddSingleton(new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                Converters = new List<JsonConverter>
                {
                    new StringEnumConverter (true)
                }
            });
        }

        private void InstallFactories(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<ICommandFactory, CommandFactory>();
        }

        private void InstallServices(IServiceCollection serviceCollection)
        {

        }
    }
}