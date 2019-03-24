using PV239_05_Storage.Core.Services.Interfaces;
using Xamarin.Forms;

namespace PV239_05_Storage.Forms.Services.Interfaces
{
    public interface IMvvmLocatorService : ISingletonService
    {
        Page ResolveView<TViewModel>(TViewModel viewModel = default);
    }
}