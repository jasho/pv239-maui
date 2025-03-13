using CommunityToolkit.Mvvm.ComponentModel;
using CookBook.Mobile.Enums;

namespace CookBook.Maui.Models;

public partial class RecipeListModel : ModelBase
{
    public Guid Id { get; set; }

    [ObservableProperty]
    public partial string Name { get; set; }

    [ObservableProperty]
    public partial FoodType FoodType { get; set; }

    [ObservableProperty]
    public partial string? ImageUrl { get; set; }
}