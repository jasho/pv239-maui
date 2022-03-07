using CookBook.Mobile.Core.Models.Ingredient;
using System;
using System.Collections.ObjectModel;

namespace CookBook.Mobile.Core.Repositories
{
    public class IngredientRepository : IIngredientRepository
    {
        public ObservableCollection<IngredientListModel> GetAll()
        {
            return new ObservableCollection<IngredientListModel>
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Vejce",
                    ImageUrl =
                        "https://upload.wikimedia.org/wikipedia/commons/thumb/5/5e/Chicken_egg_2009-06-04.jpg/428px-Chicken_egg_2009-06-04.jpg"
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Cibule",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/2/25/Onion_on_White.JPG/480px-Onion_on_White.JPG"
                }
            };
        }

        //public IngredientDetailModel GetDetail()
        //{
        //}
    }
}