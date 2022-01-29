using Microsoft.Extensions.DependencyInjection;

namespace CookBook.Mobile.Core.Installers
{
    public interface IInstaller
    {
        void Install(IServiceCollection serviceCollection);
    }
}