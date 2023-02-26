using CookBook.Mobile.Enums;

namespace CookBook.Mobile.Models;

public record RecipeListModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public FoodType FoodType { get; set; }
    public string? ImageUrl { get; set; }
}