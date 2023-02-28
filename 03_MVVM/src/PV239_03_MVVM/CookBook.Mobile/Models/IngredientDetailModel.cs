using CommunityToolkit.Mvvm.ComponentModel;

namespace CookBook.Mobile.Models;

public partial class IngredientDetailModel : ModelBase
{
    public required Guid Id { get; set; }

    [ObservableProperty]
    private string name = string.Empty;

    [ObservableProperty]
    private string description = string.Empty;

    [ObservableProperty]
    private string? imageUrl = null;
}