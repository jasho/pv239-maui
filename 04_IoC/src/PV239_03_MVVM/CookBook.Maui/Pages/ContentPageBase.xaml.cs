using CookBook.Maui.ViewModels;

namespace CookBook.Maui.Pages;

public partial class ContentPageBase
{
    public ContentPageBase(ViewModelBase viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is ViewModelBase viewModel)
        {
            await viewModel.OnAppearingAsync();
        }
    }
}