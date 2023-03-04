using CookBook.Mobile.Models;

namespace CookBook.Mobile.Clients;

public interface IRecipesClient
{
    Task<ICollection<RecipeListModel>> GetRecipesAllAsync();
    Task<RecipeDetailModel> GetRecipeByIdAsync(Guid id);
}