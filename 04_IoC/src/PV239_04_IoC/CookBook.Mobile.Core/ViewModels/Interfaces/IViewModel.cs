using System.Threading.Tasks;

namespace CookBook.Mobile.Core.ViewModels.Interfaces
{
    public interface  IViewModel
    {
        Task OnAppearingAsync();
    }

    public interface IViewModel<TViewModelParameter> : IViewModel
    {
        void SetViewModelParameter(TViewModelParameter? parameter);
    }
}