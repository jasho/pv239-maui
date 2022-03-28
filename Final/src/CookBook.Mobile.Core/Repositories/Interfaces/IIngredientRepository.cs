using CookBook.Common.Models;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace CookBook.Mobile.Core.Repositories.Interfaces
{
    public interface IIngredientRepository
    {
        Task CreateAsync(IngredientDetailModel ingredient);
        Task DeleteAsync(Guid id);
        Task<ObservableCollection<IngredientListModel>> GetAllAsync();
        Task<IngredientDetailModel> GetByIdAsync(Guid id);
        Task UpdateAsync(IngredientDetailModel ingredient);
    }
}