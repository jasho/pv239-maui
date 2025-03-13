using CookBook.Maui.ViewModels;

namespace CookBook.Maui.Pages;

public partial class MainPage
{
    public MainPage(MainViewModel viewModel)
        : base(viewModel)
    {
        InitializeComponent();
    }

    private void IngredientsButton_OnClicked(object? sender, EventArgs e)
    {
        Shell.Current.GoToAsync("./ingredient-detail");
    }
}