using AutoMapper;
using CookBook.Mobile.Entities;
using CookBook.Mobile.Models;
using CookBook.Mobile.Services;
using System.Collections.ObjectModel;

namespace CookBook.Mobile.Clients;

public class RecipesClient : IRecipesClient
{
    private readonly IDatabaseService databaseService;
    private readonly IMapper mapper;

    public RecipesClient(
        IDatabaseService databaseService,
        IMapper mapper)
    {
        this.databaseService = databaseService;
        this.mapper = mapper;
    }

    public async Task<ICollection<RecipeListModel>> GetRecipesAllAsync()
    {
        var recipeEntities = await databaseService.GetAllAsync<RecipeEntity>();
        return mapper.Map<ObservableCollection<RecipeListModel>>(recipeEntities);
    }
    
    //    => new ObservableCollection<RecipeListModel>
    //{
    //    new()
    //    {
    //        Id = Guid.NewGuid(),
    //        Name = "Míchaná vejce",
    //        FoodType = FoodType.MainDish,
    //        ImageUrl = "https://i.ibb.co/mJgrX6B/Scrambled-eggs-01.jpg"
    //    },
    //    new()
    //    {
    //        Id = Guid.NewGuid(),
    //        Name = "Miso polévka",
    //        FoodType = FoodType.Soup,
    //        ImageUrl = "https://i.ibb.co/RY1XKmL/recipe-2.jpg",
    //    },
    //    new()
    //    {
    //        Id = Guid.NewGuid(),
    //        Name = "Vykoštěné kuře s citronem a bylinkami",
    //        FoodType = FoodType.MainDish,
    //        ImageUrl = "https://i.ibb.co/QJF2ZxX/recipe-1.jpg",
    //    },
    //    new()
    //    {
    //        Id = Guid.NewGuid(),
    //        Name = "Citronový sorbet",
    //        FoodType = FoodType.Dessert,
    //    },
    //};

    public async Task<RecipeDetailModel> GetRecipeByIdAsync(Guid id)
    {
        var recipeEntity = await databaseService.GetByIdAsync<RecipeEntity>(id);
        return mapper.Map<RecipeDetailModel>(recipeEntity);
    }
        //=> new RecipeDetailModel
        //{
        //    Id = Guid.NewGuid(),
        //    Name = "Míchaná vejce",
        //    Description = "Popis míchaných vajec",
        //    Duration = TimeSpan.FromMinutes(15),
        //    FoodType = FoodType.MainDish,
        //    ImageUrl = "https://i.ibb.co/mJgrX6B/Scrambled-eggs-01.jpg"
        //};
}