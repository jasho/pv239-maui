using PV239_05_Storage.Core.Models;
using PV239_05_Storage.Core.ViewModels.Base;

namespace PV239_05_Storage.Core.ViewModels
{
    public class TodoDetailViewModel : ViewModelBase
    {
        public TodoItemModel TodoItem { get; set; }
    }
}