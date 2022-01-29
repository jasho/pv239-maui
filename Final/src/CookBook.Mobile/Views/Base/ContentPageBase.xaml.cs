using CookBook.Mobile.Core.ViewModels;

namespace CookBook.Mobile.Views
{
    public partial class ContentPageBase
    {
        public ContentPageBase(IViewModel viewModel)
        {
            BindingContext = viewModel;

            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (BindingContext is IViewModel viewModel)
            {
                await viewModel.OnAppearingAsync();
            }
        }
    }
}