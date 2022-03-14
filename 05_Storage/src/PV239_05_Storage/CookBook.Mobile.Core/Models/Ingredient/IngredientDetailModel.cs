using CookBook.Mobile.Models;

namespace CookBook.Mobile.Core.Models.Ingredient
{
    public class IngredientDetailModel : ModelBase
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
    }
}