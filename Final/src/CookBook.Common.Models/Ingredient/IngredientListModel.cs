using System;

namespace CookBook.Common.Models
{
    public record IngredientListModel(Guid Id, string Name, string? ImageUrl = null) : ModelBase
    {
        public Guid Id { get; } = Id;
        public string Name { get; } = Name;
        public string? ImageUrl { get; } = ImageUrl;
    }
}