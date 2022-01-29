using CookBook.Common.Models;
using System;
using System.Threading.Tasks;

namespace CookBook.Mobile.Core.ViewModels.Ingredient
{
    public class IngredientDetailViewModel : ViewModelBase<Guid>
    {
        public IngredientDetailModel Detail { get; set; }

        public override async Task OnAppearingAsync()
        {
            await base.OnAppearingAsync();

            Detail = new IngredientDetailModel(ViewModelParameter, "Vejce", "Prostě vejce", "https://upload.wikimedia.org/wikipedia/commons/thumb/5/5e/Chicken_egg_2009-06-04.jpg/428px-Chicken_egg_2009-06-04.jpg");
        }
    }
}