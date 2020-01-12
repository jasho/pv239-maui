using PV239_06_API.Core.ViewModels;

namespace PV239_06_API.Forms.Views
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