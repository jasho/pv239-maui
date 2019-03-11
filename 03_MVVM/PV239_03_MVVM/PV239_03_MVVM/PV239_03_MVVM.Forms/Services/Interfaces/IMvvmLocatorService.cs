using PV239_03_MVVM.Core.Services.Interfaces;
using Xamarin.Forms;

namespace PV239_03_MVVM.Forms.Services.Interfaces
{
    public interface IMvvmLocatorService : ISingletonService
    {
        Page ResolveView<TViewModel>(TViewModel viewModel = default);
    }
}