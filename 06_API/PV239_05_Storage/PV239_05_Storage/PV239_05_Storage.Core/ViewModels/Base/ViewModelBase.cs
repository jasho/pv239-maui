﻿using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace PV239_05_Storage.Core.ViewModels.Base
{
    public class ViewModelBase : INotifyPropertyChanged, IViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public virtual Task OnAppearing()
        {
            return Task.CompletedTask;
        }
    }

    public abstract class ViewModelBase<TViewModelParameter> : ViewModelBase, IViewModel<TViewModelParameter>
    {
        protected TViewModelParameter viewModelParameter;

        protected ViewModelBase(TViewModelParameter viewModelParameter)
        {
            this.viewModelParameter = viewModelParameter;
        }
    }
}