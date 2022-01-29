using System;
using System.Collections.Generic;
using Autofac;
using Microsoft.Extensions.DependencyInjection;

namespace CookBook.Mobile.Core.Services.Interfaces
{
    public interface IDependencyInjectionService
    {
        void Build(IServiceCollection serviceCollection);
        TService Resolve<TService>()
            where TService : notnull;
        TService Resolve<TService>(params TypedParameter[] parameters)
            where TService : notnull;
        object Resolve(Type type);
        object Resolve(Type type, params TypedParameter[] parameters);
        IEnumerable<TService> ResolveAll<TService>()
            where TService : notnull;
    }
}