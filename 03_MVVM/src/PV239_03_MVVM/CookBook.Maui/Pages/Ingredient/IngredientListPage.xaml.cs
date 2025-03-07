using CookBook.Maui.ViewModels;

namespace CookBook.Maui.Pages;

public partial class IngredientListPage : ContentPage
{
	public IngredientListPage()
	{
        BindingContext = new IngredientListViewModel();

		InitializeComponent();
    }
}