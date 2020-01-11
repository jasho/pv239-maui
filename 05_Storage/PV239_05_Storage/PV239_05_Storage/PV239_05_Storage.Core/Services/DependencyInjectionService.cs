using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using PV239_05_Storage.Core.Services.Interfaces;
using PV239_05_Storage.Core.ViewModels.Base;
using System;
using System.Linq;

namespace PV239_05_Storage.Core.Services
{
    public class DependencyInjectionService : IDependencyInjectionService
    {
        private IContainer container;

        public void Build(IServiceCollection serviceCollection)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.Populate(serviceCollection);
            container = containerBuilder.Build();

            var types = container.ComponentRegistry.Registrations.Where(r => typeof(IViewModel).IsAssignableFrom(r.Activator.LimitType))
                .Select(r => r.Activator.LimitType);
        }

        public TService Resolve<TService>()
        {
            return container.Resolve<TService>();
        }

        public object Resolve(Type type)
        {
            return container.Resolve(type);
        }
    }
}