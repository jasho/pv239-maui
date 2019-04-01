using PV239_05_Storage.Core.ViewModels;

namespace PV239_05_Storage.Forms.Views
{
    public partial class TodoListView
    {
        public TodoListView(TodoListViewModel viewModel)
            : base(viewModel)
        {
            InitializeComponent();
        }
    }
}