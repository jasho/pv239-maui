using CookBook.Common.Models;
using CookBook.Mobile.Core.Api;
using CookBook.Mobile.Core.Repositories.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace CookBook.Mobile.Core.Repositories
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly IIngredientsClient ingredientsClient;

        public IngredientRepository(IIngredientsClient ingredientsClient)
        {
            this.ingredientsClient = ingredientsClient;
        }

        public async Task<ObservableCollection<IngredientListModel>> GetAllAsync()
        {
            var ingredients = await ingredientsClient.GetIngredientsAllAsync();
            return new ObservableCollection<IngredientListModel>(ingredients);
        }

        public async Task<IngredientDetailModel> GetByIdAsync(Guid id)
            => await ingredientsClient.GetIngredientByIdAsync(id);

        public async Task CreateAsync(IngredientDetailModel ingredient)
            => await ingredientsClient.CreateIngredientAsync(ingredient);

        public async Task UpdateAsync(IngredientDetailModel ingredient)
           => await ingredientsClient.UpdateIngredientAsync(ingredient);

        public async Task DeleteAsync(Guid id)
           => await ingredientsClient.DeleteIngredientAsync(id);
    }
}
