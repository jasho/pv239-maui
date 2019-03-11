using Microsoft.Extensions.DependencyInjection;
using PV239_03_MVVM.Core.Factories.Interfaces;
using PV239_03_MVVM.Core.Services.Interfaces;
using PV239_03_MVVM.Core.ViewModels.Base;

namespace PV239_03_MVVM.Core.Installers
{
    public class CoreInstaller
    {
        public void Install(IServiceCollection serviceCollection, IDependencyInjectionService dependencyInjectionService)
        {
            serviceCollection.AddSingleton<IDependencyInjectionService>(dependencyInjectionService);

            serviceCollection.Scan(scan => scan
                .FromAssemblyOf<CoreInstaller>()
                .AddClasses(classes => classes.AssignableTo<IFactory>())
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
            );
        }
    }
}