using CommunityToolkit.Mvvm.ComponentModel;
using CookBook.Mobile.Enums;

namespace CookBook.Mobile.Models;

public partial class RecipeListModel : ModelBase
{
    public Guid Id { get; set; }

    [ObservableProperty]
    private string name = string.Empty;

    [ObservableProperty]
    private FoodType foodType;

    [ObservableProperty]
    private string? imageUrl = null;
}