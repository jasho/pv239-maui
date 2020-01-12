using PV239_06_API.Core.ViewModels;
using Xamarin.Forms.Xaml;

namespace PV239_06_API.Forms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TodoDetailView
    {
        public TodoDetailView(TodoDetailViewModel viewModel)
            : base(viewModel)
        {
            InitializeComponent();
        }
    }
}