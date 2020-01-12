using PV239_06_API.Core.ViewModels.Base;
using Xamarin.Forms.Xaml;

namespace PV239_06_API.Forms.Views
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