using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CookBook.Mobile.Models;

namespace CookBook.Mobile.ViewModels.Ingredient;

public partial class IngredientListViewModel : ViewModelBase
{
    [ObservableProperty]
    private ICollection<IngredientListModel> items = new List<IngredientListModel>()
    {
        new()
        {
            Id = Guid.NewGuid(),
            Name = "Vejce",
            ImageUrl = "https://i.ibb.co/d7mZWGN/image.jpg"
        },
        new()
        {
            Id = Guid.NewGuid(),
            Name = "Cibule",
            ImageUrl = "https://i.ibb.co/sbXC0rS/480px-Onion-on-White.jpg"
        },
        new()
        {
            Id = Guid.NewGuid(),
            Name = "Slanina",
        },
        new()
        {
            Id = Guid.NewGuid(),
            Name = "Rajče",
            ImageUrl = "https://i.ibb.co/1TzsF6B/ingredient-7.jpg"
        },
        new()
        {
            Id = Guid.NewGuid(),
            Name = "Mléko",
            ImageUrl = "https://i.ibb.co/BB3gVxr/ingredient-2.jpg"
        }
    };

    [RelayCommand]
    private void GoToDetail(Guid id)
    {
        Shell.Current.GoToAsync("detail");
    }

    [RelayCommand]
    private void GoToCreate()
    {
    }

    [RelayCommand]
    private void GoToEdit(Guid id)
    {
    }
}