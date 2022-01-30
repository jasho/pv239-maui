using CookBook.Mobile.Core.ViewModels.Recipe;

namespace CookBook.Mobile.Views.Recipe
{
    public partial class RecipeDetailView
    {
        public RecipeDetailView(RecipeDetailViewModel viewModel)
            : base(viewModel)
        {
            InitializeComponent();
        }
    }
}