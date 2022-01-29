using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using CookBook.Mobile.Core.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CookBook.Mobile.Core.Services
{
    public class DependencyInjectionService : IDependencyInjectionService
    {
        private IContainer? container;

        public void Build(IServiceCollection serviceCollection)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.Populate(serviceCollection);
            container = containerBuilder.Build();
        }

        public TService Resolve<TService>()
            where TService : notnull
        {
            return container!.Resolve<TService>();
        }

        public TService Resolve<TService>(params TypedParameter[] parameters)
            where TService : notnull
        {
            if (parameters.Any())
            {
                var typedParameters = parameters.Select(parameter => new Autofac.TypedParameter(parameter.Type, parameter.Value)).ToList();
                return container!.Resolve<TService>(typedParameters);
            }

            return container!.Resolve<TService>();
        }

        public object Resolve(Type type)
        {
            return container!.Resolve(type);
        }

        public object Resolve(Type type, params TypedParameter[] parameters)
        {
            if (parameters.Any())
            {
                var typedParameters = parameters.Select(parameter => new Autofac.TypedParameter(parameter.Type, parameter.Value)).ToList();
                return container!.Resolve(type, typedParameters);
            }

            return container!.Resolve(type);
        }

        public IEnumerable<TService> ResolveAll<TService>()
            where TService : notnull
        {
            return container!.Resolve<IEnumerable<TService>>();
        }
    }
}