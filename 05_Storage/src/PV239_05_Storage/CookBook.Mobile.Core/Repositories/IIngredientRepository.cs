using CookBook.Mobile.Core.Models.Ingredient;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace CookBook.Mobile.Core.Repositories
{
    public interface IIngredientRepository
    {
        Task<ObservableCollection<IngredientListModel>> GetAllAsync();
        Task<IngredientDetailModel> GetByIdAsync(Guid id);
    }
}