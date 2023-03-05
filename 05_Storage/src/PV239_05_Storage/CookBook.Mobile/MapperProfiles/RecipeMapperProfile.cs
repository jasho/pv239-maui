using AutoMapper;
using CookBook.Mobile.Entities;
using CookBook.Mobile.Models;

namespace CookBook.Mobile.MapperProfiles;

public class RecipeMapperProfile : Profile
{
    public RecipeMapperProfile()
    {
        CreateMap<RecipeEntity, RecipeListModel>();
        CreateMap<RecipeEntity, RecipeDetailModel>();

        CreateMap<RecipeDetailModel, RecipeEntity>();
    }
}