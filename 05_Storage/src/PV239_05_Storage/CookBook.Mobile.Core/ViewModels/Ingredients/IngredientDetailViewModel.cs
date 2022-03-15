using CookBook.Mobile.Core.Models.Ingredient;
using CookBook.Mobile.Core.Repositories;
using System;
using System.Threading.Tasks;

namespace CookBook.Mobile.Core.ViewModels.Ingredients
{
    public class IngredientDetailViewModel : ViewModelBase<Guid>
    {
        private readonly IIngredientRepository ingredientRepository;
        public IngredientDetailModel Ingredient { get; set; }

        public IngredientDetailViewModel(IIngredientRepository ingredientRepository)
        {
            this.ingredientRepository = ingredientRepository;
        }

        public override async Task OnAppearingAsync()
        {
            await base.OnAppearingAsync();

            Ingredient = await ingredientRepository.GetByIdAsync(ViewModelParameter);
        }
    }
}