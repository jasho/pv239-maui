using System;
using Microsoft.Extensions.DependencyInjection;

namespace PV239_03_MVVM.Core.Services.Interfaces
{
    public interface IDependencyInjectionService
    {
        void Build(IServiceCollection serviceCollection);
        TService Resolve<TService>();
        object Resolve(Type type);
    }
}