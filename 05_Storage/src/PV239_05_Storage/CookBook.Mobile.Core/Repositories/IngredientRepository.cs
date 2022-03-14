using AutoMapper;
using CookBook.Mobile.Core.Entities;
using CookBook.Mobile.Core.Models.Ingredient;
using CookBook.Mobile.Core.Services;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace CookBook.Mobile.Core.Repositories
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly IDatabaseService databaseService;
        private readonly IMapper mapper;

        public IngredientRepository(
            IDatabaseService databaseService,
            IMapper mapper)
        {
            this.databaseService = databaseService;
            this.mapper = mapper;
        }

        public async Task<ObservableCollection<IngredientListModel>> GetAllAsync()
        {
            var ingredientEntities = await databaseService.GetAllAsync<IngredientEntity>();

            return mapper.Map<ObservableCollection<IngredientListModel>>(ingredientEntities);
        }

        public async Task<IngredientDetailModel> GetByIdAsync(Guid id)
        {
            var ingredientEntity = await databaseService.GetByIdAsync<IngredientEntity>(id);
            return mapper.Map<IngredientDetailModel>(ingredientEntity);
        }
    }
}