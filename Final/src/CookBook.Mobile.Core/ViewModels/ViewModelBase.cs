using CookBook.Mobile.Core.Enums;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace CookBook.Mobile.Core.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged, IViewModel
    {
        public AppState State { get; set; } = AppState.None;

        public event PropertyChangedEventHandler? PropertyChanged;
        
        public virtual Task OnAppearingAsync()
        {
            return Task.CompletedTask;
        }

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public abstract class ViewModelBase<TViewModelParameter> : ViewModelBase, IViewModel<TViewModelParameter>
    {
        protected TViewModelParameter? ViewModelParameter;
        
        public virtual void SetViewModelParameter(TViewModelParameter? parameter)
        {
            ViewModelParameter = parameter;
        }
    }
}