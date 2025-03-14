using CookBook.Maui.ViewModels.Recipe;

namespace CookBook.Maui.Pages.Recipe;

public partial class RecipeDetailPage
{
	public RecipeDetailPage(RecipeDetailViewModel viewModel) : base(viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}