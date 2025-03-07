using CommunityToolkit.Mvvm.ComponentModel;
using CookBook.Maui.Models;

namespace CookBook.Maui.ViewModels;

public partial class IngredientListViewModel : ViewModelBase
{
    [ObservableProperty]
    public partial List<IngredientListModel> Items { get; set; } =
    [
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
    ];
}
