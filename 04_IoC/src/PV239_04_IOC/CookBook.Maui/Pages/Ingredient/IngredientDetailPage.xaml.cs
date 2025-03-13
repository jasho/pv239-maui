using CookBook.Maui.ViewModels.Ingredient;

namespace CookBook.Maui.Pages;

public partial class IngredientDetailPage
{
    public IngredientDetailPage(IngredientDetailViewModel viewModel)
        : base(viewModel)
    {
        InitializeComponent();
    }
}