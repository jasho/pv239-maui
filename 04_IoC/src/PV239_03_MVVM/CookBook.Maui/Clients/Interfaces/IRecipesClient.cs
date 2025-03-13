using CookBook.Maui.Models;

namespace CookBook.Maui.Clients.Interfaces
{
    internal interface IRecipesClient
    {
        Task<ICollection<RecipeListModel>> GetRecipesAllAsync();
        Task<RecipeDetailModel> GetRecipeByIdAsync(Guid id);
    }
}
