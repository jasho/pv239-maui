using AutoMapper;
using CookBook.Mobile.Entities;
using CookBook.Mobile.Models;

namespace CookBook.Mobile.MapperProfiles;

public class IngredientMapperProfile : Profile
{
    public IngredientMapperProfile()
    {
        CreateMap<IngredientEntity, IngredientListModel>();
        CreateMap<IngredientEntity, IngredientDetailModel>();
        
        CreateMap<IngredientDetailModel, IngredientEntity>();
    }
}