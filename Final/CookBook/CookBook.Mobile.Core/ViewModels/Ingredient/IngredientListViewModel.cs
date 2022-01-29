using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CookBook.Common.Models;

namespace CookBook.Mobile.Core.ViewModels.Ingredient
{
    public class IngredientListViewModel : ViewModelBase
    {
        public ObservableCollection<IngredientListModel> Items { get; set; }

        public override async Task OnAppearingAsync()
        {
            await base.OnAppearingAsync();

            Items = new ObservableCollection<IngredientListModel>
            {
                new (Guid.NewGuid(), "Vejce", "https://upload.wikimedia.org/wikipedia/commons/thumb/5/5e/Chicken_egg_2009-06-04.jpg/428px-Chicken_egg_2009-06-04.jpg"),
                new (Guid.NewGuid(), "Cibule", "https://upload.wikimedia.org/wikipedia/commons/thumb/2/25/Onion_on_White.JPG/480px-Onion_on_White.JPG"),
            };
        }
    }
}