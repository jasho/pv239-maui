using CookBook.Mobile.Core.ViewModels.Ingredients;

namespace CookBook.Mobile.Views.Ingredients
{
    public partial class IngredientListView
    {
        public IngredientListView(IngredientListViewModel ingredientListViewModel)
            : base(ingredientListViewModel)
        {
            InitializeComponent();
        }
    }
}