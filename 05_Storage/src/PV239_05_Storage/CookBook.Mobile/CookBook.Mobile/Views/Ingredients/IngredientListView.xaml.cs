using CookBook.Mobile.Core.Factories;
using CookBook.Mobile.Core.Repositories;
using CookBook.Mobile.Core.Services;
using CookBook.Mobile.Core.ViewModels.Ingredients;
using CookBook.Mobile.Services;

namespace CookBook.Mobile.Views.Ingredients
{
    public partial class IngredientListView
    {
        public IngredientListView(IngredientListViewModel ingredientListViewModel)
            : base(ingredientListViewModel)
        {
            InitializeComponent();

            BindingContext = ingredientListViewModel;
        }
    }
}