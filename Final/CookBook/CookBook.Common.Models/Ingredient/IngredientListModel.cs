using System;

namespace CookBook.Common.Models
{
    public record IngredientListModel(Guid Id, string Name, string? ImageUrl = null)
    {
        public Guid Id { get; set; } = Id;
        public string Name { get; set; } = Name;
        public string? ImageUrl { get; set; } = ImageUrl;
    }
}