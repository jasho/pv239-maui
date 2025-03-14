using CookBook.Maui.Models;

namespace CookBook.Maui.Clients.Interfaces
{
    public interface IRecipesClient
    {
        Task<ICollection<RecipeListModel>> GetRecipesAllAsync();
        Task<RecipeDetailModel?> GetRecipeByIdAsync(Guid id);
    }
}
