using PV239_03_MVVM.Core.ViewModels;

namespace PV239_03_MVVM.Forms.Views
{
    public partial class TodoListView
    {
        public TodoListView(TodoListViewModel todoListViewModel)
        {
            BindingContext = todoListViewModel;
            InitializeComponent();
        }
    }
}