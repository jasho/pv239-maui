using CommunityToolkit.Mvvm.ComponentModel;
using CookBook.Maui.Clients.Interfaces;
using CookBook.Maui.Models;
using CookBook.Mobile.Enums;

namespace CookBook.Maui.ViewModels.Recipe;

[QueryProperty(nameof(RecipeId), nameof(RecipeId))]
public partial class RecipeDetailViewModel(IRecipesClient recipesClient) : ViewModelBase
{
    public Guid RecipeId { get; set; }
    
    [ObservableProperty]
    public partial RecipeDetailModel? Recipe { get; set; }

    protected override async Task LoadDataAsync()
    {
        Recipe = await recipesClient.GetRecipeByIdAsync(RecipeId);
    }
}