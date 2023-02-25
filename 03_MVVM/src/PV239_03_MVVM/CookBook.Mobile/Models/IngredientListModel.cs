namespace CookBook.Mobile.Models;

public record IngredientListModel
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public string? ImageUrl { get; set; } = null;
}