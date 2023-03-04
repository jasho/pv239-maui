using CookBook.Mobile.ViewModels.Ingredient;

namespace CookBook.Mobile.Views.Ingredient;

public partial class IngredientDetailView
{
    public IngredientDetailView(IngredientDetailViewModel ingredientDetailViewModel)
        : base(ingredientDetailViewModel)
    {
        InitializeComponent();
    }
}