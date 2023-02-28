using CookBook.Mobile.ViewModels.Ingredient;

namespace CookBook.Mobile.Views.Ingredient;

public partial class IngredientListView
{
    public IngredientListView()
    {
        InitializeComponent();

        BindingContext = new IngredientListViewModel();
    }
}