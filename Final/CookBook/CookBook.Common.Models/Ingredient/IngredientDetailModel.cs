using System;

namespace CookBook.Common.Models
{
    public record IngredientDetailModel(Guid Id, string Name, string Description, string? ImageUrl = null)
    {
        public Guid Id { get; } = Id;
        public string Name { get; } = Name;
        public string Description { get; } = Description;
        public string? ImageUrl { get; } = ImageUrl;
    }
}