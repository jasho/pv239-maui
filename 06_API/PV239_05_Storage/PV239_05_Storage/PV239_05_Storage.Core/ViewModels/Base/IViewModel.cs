using System.Threading.Tasks;

namespace PV239_05_Storage.Core.ViewModels.Base
{
    public interface IViewModel
    {
        Task OnAppearing();
    }

    public interface IViewModel<TViewModelParameter> : IViewModel
    {
    }
}