using CookBook.Mobile.ViewModels.Ingredient;

namespace CookBook.Mobile.Views.Ingredient;

public partial class IngredientDetailView
{
    public IngredientDetailView()
    {
        InitializeComponent();
        BindingContext = new IngredientDetailViewModel();
    }
}