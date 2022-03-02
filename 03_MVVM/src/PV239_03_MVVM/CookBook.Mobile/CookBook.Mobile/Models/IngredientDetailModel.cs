using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CookBook.Mobile.Models
{
    public class IngredientDetailModel : ModelBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}