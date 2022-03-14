using CookBook.Mobile.Models;
using System;

namespace CookBook.Mobile.Core.Models.Ingredient
{
    public class IngredientListModel : ModelBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? ImageUrl { get; set; }
    }
}