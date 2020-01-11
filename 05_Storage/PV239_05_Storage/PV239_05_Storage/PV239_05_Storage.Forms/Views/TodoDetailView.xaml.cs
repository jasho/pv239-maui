using PV239_05_Storage.Core.ViewModels;
using Xamarin.Forms.Xaml;

namespace PV239_05_Storage.Forms.Views
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