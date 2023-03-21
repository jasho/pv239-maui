using AutoMapper;
using CookBook.Mobile.Entities;
using CookBook.Mobile.Models;
using CookBook.Mobile.Services;
using System.Collections.ObjectModel;

namespace CookBook.Mobile.Clients;

public class IngredientsClient : IIngredientsClient
{
    private readonly IDatabaseService databaseService;
    private readonly IMapper mapper;

    public IngredientsClient(
        IDatabaseService databaseService,
        IMapper mapper)
    {
        this.databaseService = databaseService;
        this.mapper = mapper;
    }
    
    public async Task<ICollection<IngredientListModel>> GetIngredientsAllAsync()
    {
        var ingredientEntities = await databaseService.GetAllAsync<IngredientEntity>();
        return mapper.Map<ObservableCollection<IngredientListModel>>(ingredientEntities);
    }

    public async Task<IngredientDetailModel> GetIngredientByIdAsync(Guid id) 
    {
        var ingredientEntity = await databaseService.GetByIdAsync<IngredientEntity>(id);
        return mapper.Map<IngredientDetailModel>(ingredientEntity);
    }
}