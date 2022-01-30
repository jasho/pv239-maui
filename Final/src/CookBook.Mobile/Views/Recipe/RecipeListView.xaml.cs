using CookBook.Mobile.Core.ViewModels.Recipe;

namespace CookBook.Mobile.Views.Recipe
{
    public partial class RecipeListView
    {
        public RecipeListView(RecipeListViewModel viewModel)
            : base(viewModel)
        {
            InitializeComponent();
        }
    }
}