using System.Threading.Tasks;

namespace PV239_03_MVVM.Core.Services.Interfaces
{
    public interface INavigationService : ISingletonService
    {
        Task PushAsync<TViewModel>(TViewModel viewModel = default, bool animated = default, bool clearHistory = default);
        Task PopAsync(bool animated = default);
        Task PopToRootAsync(bool animated = default);
    }
}