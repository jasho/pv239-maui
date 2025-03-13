using CookBook.Maui.ViewModels;

namespace CookBook.Maui.Pages;

public partial class IngredientListPage
{
    public IngredientListPage(IngredientListViewModel viewModel)
        : base(viewModel)
    {
        InitializeComponent();
    }
}