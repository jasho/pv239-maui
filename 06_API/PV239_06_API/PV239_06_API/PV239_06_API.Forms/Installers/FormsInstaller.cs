using Microsoft.Extensions.DependencyInjection;
using PV239_06_API.Core.Services.Interfaces;
using PV239_06_API.Forms.Views;
using Xamarin.Forms;

namespace PV239_06_API.Forms.Installers
{
    public class FormsInstaller
    {
        public void Install(IServiceCollection serviceCollection, INavigation navigation)
        {
            serviceCollection.AddSingleton<INavigation>(navigation);

            serviceCollection.Scan(scan => scan
                .FromAssemblyOf<FormsInstaller>()
                .AddClasses(classes => classes.AssignableTo<ViewBase>())
                    .AsSelf()
                    .WithTransientLifetime()
                .AddClasses(classes => classes.AssignableTo<ISingletonService>())
                    .AsSelfWithInterfaces()
                    .WithSingletonLifetime()
                .AddClasses(classes => classes.AssignableTo<ITransientService>())
                    .AsSelfWithInterfaces()
                    .WithTransientLifetime()
            );
        }
    }
}