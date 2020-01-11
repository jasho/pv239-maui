using Microsoft.Extensions.DependencyInjection;
using System;

namespace PV239_05_Storage.Core.Services.Interfaces
{
    public interface IDependencyInjectionService
    {
        void Build(IServiceCollection serviceCollection);
        TService Resolve<TService>();
        object Resolve(Type type);
    }
}