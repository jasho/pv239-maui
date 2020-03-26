using Microsoft.Extensions.DependencyInjection;

namespace PV239_06_API.Core.Installers
{
    public interface IInstaller
    {
        public void Install(IServiceCollection serviceCollection);
    }
}