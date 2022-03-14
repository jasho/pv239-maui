using CookBook.Mobile.Core.Models.Ingredient;
using System.Collections.ObjectModel;

namespace CookBook.Mobile.Core.Repositories
{
    public interface IIngredientRepository
    {
        ObservableCollection<IngredientListModel> GetAll();
    }
}