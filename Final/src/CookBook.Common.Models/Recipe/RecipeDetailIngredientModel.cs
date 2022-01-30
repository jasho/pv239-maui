using CookBook.Common.Enums;
using System;

namespace CookBook.Common.Models
{
    public record RecipeDetailIngredientModel(Guid? Id, double Amount, Unit Unit, IngredientListModel Ingredient) : ModelBase
    {
        public Guid? Id { get; } = Id;
        public double Amount { get; } = Amount;
        public Unit Unit { get; } = Unit;
        public IngredientListModel Ingredient { get; } = Ingredient;
    }
}