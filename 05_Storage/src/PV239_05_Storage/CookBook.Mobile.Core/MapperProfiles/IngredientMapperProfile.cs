using AutoMapper;
using CookBook.Mobile.Core.Entities;
using CookBook.Mobile.Core.Models.Ingredient;

namespace CookBook.Mobile.Core.MapperProfiles
{
    public class IngredientMapperProfile : Profile
    {
        public IngredientMapperProfile()
        {
            CreateMap<IngredientEntity, IngredientListModel>();
            CreateMap<IngredientEntity, IngredientDetailModel>();
            
            CreateMap<IngredientDetailModel, IngredientEntity>();
        }
    }
}