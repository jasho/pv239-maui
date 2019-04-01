using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using PV239_05_Storage.Core.Ioc;

namespace PV239_05_Storage.Core.Services.Interfaces
{
    public interface IDependencyInjectionService
    {
        void Build(IServiceCollection serviceCollection);
        TService Resolve<TService>();
        TService Resolve<TService>(params TypedParameter[] parameters);
        object Resolve(Type type);
        object Resolve(Type type, params TypedParameter[] parameters);
        IEnumerable<TService> ResolveAll<TService>();
    }
}