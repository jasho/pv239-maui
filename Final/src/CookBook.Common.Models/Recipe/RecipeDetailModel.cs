using CookBook.Common.Enums;
using System;
using System.Collections.Generic;

namespace CookBook.Common.Models
{
    public record RecipeDetailModel(Guid? Id, string Name, string Description, TimeSpan Duration, FoodType FoodType, IList<RecipeDetailIngredientModel> IngredientAmounts, string? ImageUrl = null) : ModelBase
    {
        public Guid? Id { get; } = Id;
        public string Name { get; set; } = Name;
        public string Description { get; set; } = Description;
        public TimeSpan Duration { get; set; } = Duration;
        public FoodType FoodType { get; set; } = FoodType;
        public IList<RecipeDetailIngredientModel> IngredientAmounts { get; set; } = IngredientAmounts;
        public string? ImageUrl { get; set;  } = ImageUrl;
    }
}