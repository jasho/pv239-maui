using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CookBook.Mobile.Enums;
using CookBook.Mobile.Models;
using System.Collections.ObjectModel;

namespace CookBook.Mobile.ViewModels.Recipe;

public partial class RecipeListViewModel : ViewModelBase
{
    [ObservableProperty]
    private ObservableCollection<RecipeListModel>? items = new ObservableCollection<RecipeListModel>()
    {
        new()
        {
            Id = Guid.NewGuid(),
            Name = "Míchaná vejce",
            FoodType = FoodType.MainDish,
            ImageUrl = "https://i.ibb.co/mJgrX6B/Scrambled-eggs-01.jpg"
        },
        new()
        {
            Id = Guid.NewGuid(),
            Name = "Miso polévka",
            FoodType = FoodType.Soup,
            ImageUrl = "https://i.ibb.co/RY1XKmL/recipe-2.jpg",
        },
        new()
        {
            Id = Guid.NewGuid(),
            Name = "Vykoštěné kuře s citronem a bylinkami",
            FoodType = FoodType.MainDish,
            ImageUrl = "https://i.ibb.co/QJF2ZxX/recipe-1.jpg",
        },
        new()
        {
            Id = Guid.NewGuid(),
            Name = "Citronový sorbet",
            FoodType = FoodType.Dessert,
        },
    };

    [RelayCommand]
    private void GoToDetail(Guid id)
    {
    }

    [RelayCommand]
    private void GoToCreate()
    {
    }
}