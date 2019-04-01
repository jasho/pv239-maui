using System;
using PV239_05_Storage.Core.Models;
using PV239_05_Storage.Core.ViewModels.Base;

namespace PV239_05_Storage.Core.ViewModels
{
    public class TodoDetailViewModel : ViewModelBase<Guid>
    {
        public TodoItemModel TodoItem { get; set; }

        public TodoDetailViewModel(Guid viewModelParameter)
            : base(viewModelParameter)
        {
        }
    }
}