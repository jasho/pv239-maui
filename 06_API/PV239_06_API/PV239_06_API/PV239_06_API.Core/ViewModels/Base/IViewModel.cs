using System.Threading.Tasks;

namespace PV239_06_API.Core.ViewModels.Base
{
    public interface IViewModel
    {
        Task OnAppearing();
    }

    public interface IViewModel<TViewModelParameter> : IViewModel
    {
    }
}