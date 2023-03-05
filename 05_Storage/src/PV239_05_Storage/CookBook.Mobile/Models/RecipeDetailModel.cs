using CommunityToolkit.Mvvm.ComponentModel;
using CookBook.Mobile.Enums;

namespace CookBook.Mobile.Models;

public partial class RecipeDetailModel : ModelBase
{
    public Guid? Id { get; set; }

    [ObservableProperty]
    private string name;

    [ObservableProperty]
    private string? description;

    [ObservableProperty]
    private TimeSpan duration;

    [ObservableProperty]
    private FoodType foodType;

    [ObservableProperty]
    private string? imageUrl;
}