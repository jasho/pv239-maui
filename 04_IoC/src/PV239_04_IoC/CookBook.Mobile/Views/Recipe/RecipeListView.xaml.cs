using CookBook.Mobile.ViewModels.Recipe;

namespace CookBook.Mobile.Views.Recipe;

public partial class RecipeListView
{
    public RecipeListView(RecipeListViewModel recipeListViewModel)
        : base(recipeListViewModel)
    {
        InitializeComponent();
    }
}