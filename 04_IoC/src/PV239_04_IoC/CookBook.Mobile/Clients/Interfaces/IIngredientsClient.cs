using CookBook.Mobile.Models;

namespace CookBook.Mobile.Clients;

public interface IIngredientsClient
{
    Task<ICollection<IngredientListModel>> GetIngredientsAllAsync();
    Task<IngredientDetailModel> GetIngredientByIdAsync(Guid id);
}