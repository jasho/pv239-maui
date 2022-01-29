using System;

namespace CookBook.Common.Models
{
    public record IngredientDetailModel(Guid Id, string Name, string Description, string? ImageUrl = null) : ModelBase
    {
        public Guid Id { get; } = Id;
        public string Name { get; set; } = Name;
        public string Description { get; set; } = Description;
        public string? ImageUrl { get; set; } = ImageUrl;
    }
}