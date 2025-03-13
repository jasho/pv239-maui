using CookBook.Maui.Clients.Interfaces;
using CookBook.Maui.Models;
using CookBook.Mobile.Enums;

namespace CookBook.Maui.Clients;

public class RecipesClient : IRecipesClient
{
    private List<RecipeDetailModel> items =
    [
        new()
        {
            Id = Guid.NewGuid(),
            Name = "Míchaná vejce",
            Description = "K přípravě míchaných vajec jsou třeba vejce, cibule, tuk, sůl a popřípadě též uzenina a na dozdobení pažitka nebo petrželka. Na tuku se dozlatova osmaží cibulka. Následně se do ní přidá uzenina (je-li jako přísada zvolena) a nechá se osmahnout. Dále se do směsi přidají celá vejce. Pokrm se osolí a za stálého míchání se nechá ztuhnout. Závěrem je možné dozdobit pažitkou nebo petrželkou.[6]",
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
            Name = "Sorbet",
            Description = "Sorbet je dezert, který se vyrábí smícháním ledu s cukrem nebo medem a rozdrceným ovocem (citron, limeta, ananas, jahoda, malina, ostružina apod.), může být dochucen vínem nebo destilátem. Podává se v misce nebo poháru a jí se lžičkou. Podíl ovocné složky by měl činit minimálně 25 procent.",
            FoodType = FoodType.Dessert,
        },
    ];

    public async Task<ICollection<RecipeListModel>> GetRecipesAllAsync()
        => items.Select(recipe => new RecipeListModel
        {
            Id = recipe.Id ?? Guid.Empty,
            Name = recipe.Name,
            FoodType = recipe.FoodType,
            ImageUrl = recipe.ImageUrl
        })
        .ToList();

    public async Task<RecipeDetailModel?> GetRecipeByIdAsync(Guid id)
        => items.FirstOrDefault(recipe => recipe.Id == id);
}