using CookBook.Mobile.ViewModels.Recipe;

namespace CookBook.Mobile.Views.Recipe;

public partial class RecipeListView
{
    public RecipeListView()
    {
        InitializeComponent();
        BindingContext = new RecipeListViewModel();
    }
}