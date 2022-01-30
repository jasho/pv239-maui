using System;
using CookBook.Common.Enums;

namespace CookBook.Common.Models
{
    public record RecipeListModel(Guid Id, string Name, TimeSpan Duration, FoodType FoodType, string? ImageUrl = null) : ModelBase
    {
        public Guid Id { get; } = Id;
        public string Name { get; } = Name;
        public TimeSpan Duration { get; } = Duration;
        public FoodType FoodType { get; } = FoodType;
        public string? ImageUrl { get; } = ImageUrl;
    }
}