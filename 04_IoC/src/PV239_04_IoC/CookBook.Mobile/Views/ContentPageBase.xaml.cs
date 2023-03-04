using CookBook.Mobile.ViewModels;

namespace CookBook.Mobile.Views;

public partial class ContentPageBase
{
    private ViewModelBase viewModel;

    public ContentPageBase(ViewModelBase viewModel)
    {
        InitializeComponent();

        this.viewModel = viewModel;
        BindingContext = this.viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await viewModel.OnAppearingAsync();
    }
}