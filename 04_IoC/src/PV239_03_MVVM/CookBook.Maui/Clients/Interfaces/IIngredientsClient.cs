using CookBook.Maui.Models;

namespace CookBook.Maui.Clients.Interfaces;

public interface IIngredientsClient
{
    Task<ICollection<IngredientListModel>> GetIngredientsAllAsync();
    Task<IngredientDetailModel?> GetIngredientByIdAsync(Guid id);
}