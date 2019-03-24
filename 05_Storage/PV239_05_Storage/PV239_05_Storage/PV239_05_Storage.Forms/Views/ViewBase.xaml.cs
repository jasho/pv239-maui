using PV239_05_Storage.Core.ViewModels.Base;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PV239_05_Storage.Forms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewBase
    {
        private readonly IViewModel viewModel;

        public ViewBase(IViewModel viewModel)
        {
            this.viewModel = viewModel;
            BindingContext = this.viewModel;
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await viewModel?.OnAppearing();
        }
    }
}