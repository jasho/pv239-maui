using Microsoft.Extensions.DependencyInjection;
using PV239_06_API.Core.Api;
using PV239_06_API.Core.Config;
using PV239_06_API.Core.Factories.Interfaces;
using PV239_06_API.Core.Mappings;
using PV239_06_API.Core.Services.Interfaces;
using PV239_06_API.Core.ViewModels.Base;

namespace PV239_06_API.Core.Installers
{
    public class CoreInstaller
    {
        public void Install(IServiceCollection serviceCollection, IDependencyInjectionService dependencyInjectionService)
        {
            serviceCollection.AddSingleton<IDependencyInjectionService>(dependencyInjectionService);
            serviceCollection.AddSingleton<IApiClient, ApiClient>();

            serviceCollection.Scan(scan => scan
                .FromAssemblyOf<CoreInstaller>()
                .AddClasses(classes => classes.AssignableTo<IFactory>())
                    .AsSelfWithInterfaces()
                    .WithSingletonLifetime()
                .AddClasses(classes => classes.AssignableTo<IConfig>())
                    .AsSelfWithInterfaces()
                    .WithSingletonLifetime()
                .AddClasses(classes => classes.AssignableTo<ISingletonService>())
                    .AsSelfWithInterfaces()
                    .WithSingletonLifetime()
                .AddClasses(classes => classes.AssignableTo<ITransientService>())
                    .AsSelfWithInterfaces()
                    .WithTransientLifetime()
                .AddClasses(classes => classes.AssignableTo<IViewModel>())
                    .AsSelfWithInterfaces()
                    .WithTransientLifetime()
                .AddClasses(classes => classes.AssignableTo<IMapping>())
                    .AsSelfWithInterfaces()
                    .WithSingletonLifetime()
            );
        }
    }
}