using CookBook.Maui.Clients;
using CookBook.Maui.ViewModels.Recipe;

namespace CookBook.Maui.Pages.Recipe;

public partial class RecipeListPage : ContentPage
{
    public RecipeListPage(RecipeListViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;
    }
}