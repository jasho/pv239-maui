using CookBook.Maui.Clients.Interfaces;
using CookBook.Maui.Models;
using CookBook.Mobile.Enums;
using System.Collections.ObjectModel;

namespace CookBook.Maui.Clients;

public class RecipesClient : IRecipesClient
{
    public async Task<ICollection<RecipeListModel>> GetRecipesAllAsync()
        => new ObservableCollection<RecipeListModel>
        {
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Míchaná vejce",
                FoodType = FoodType.MainDish,
                ImageUrl = "https://i.ibb.co/mJgrX6B/Scrambled-eggs-01.jpg"
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Miso polévka",
                FoodType = FoodType.Soup,
                ImageUrl = "https://i.ibb.co/RY1XKmL/recipe-2.jpg",
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Vykoštěné kuře s citronem a bylinkami",
                FoodType = FoodType.MainDish,
                ImageUrl = "https://i.ibb.co/QJF2ZxX/recipe-1.jpg",
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Citronový sorbet",
                FoodType = FoodType.Dessert,
            },
        };

    public async Task<RecipeDetailModel> GetRecipeByIdAsync(Guid id)
        => new RecipeDetailModel
        {
            Id = Guid.NewGuid(),
            Name = "Míchaná vejce",
            Description = "Popis míchaných vajec",
            Duration = TimeSpan.FromMinutes(15),
            FoodType = FoodType.MainDish,
            ImageUrl = "https://i.ibb.co/mJgrX6B/Scrambled-eggs-01.jpg"
        };
}