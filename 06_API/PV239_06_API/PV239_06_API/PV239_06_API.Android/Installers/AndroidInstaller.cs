using Microsoft.Extensions.DependencyInjection;
using PV239_06_API.Core.Installers;
using System.Net.Http;
using Xamarin.Android.Net;

namespace PV239_06_API.Droid.Installers
{
    public class AndroidInstaller : IInstaller
    {
        public void Install(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<HttpClient>(factory => new HttpClient(new IgnoreSSLClientHandler()));
        }
    }
}