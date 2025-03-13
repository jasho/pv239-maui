using CommunityToolkit.Mvvm.ComponentModel;

namespace CookBook.Maui.Models;

public partial class IngredientListModel : ModelBase
{
    public required Guid Id { get; set; }

    [ObservableProperty]
    public partial string Name { get; set; }

    [ObservableProperty]
    public partial string? ImageUrl { get; set; }
}