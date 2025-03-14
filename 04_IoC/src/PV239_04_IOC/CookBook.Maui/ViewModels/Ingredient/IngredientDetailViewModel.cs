using CommunityToolkit.Mvvm.ComponentModel;
using CookBook.Maui.Clients.Interfaces;
using CookBook.Maui.Models;

namespace CookBook.Maui.ViewModels.Ingredient;

[QueryProperty(nameof(Id), nameof(Id))]
public partial class IngredientDetailViewModel(IIngredientsClient ingredientsClient)
    : ViewModelBase
{
    public Guid Id { get; set; }

    [ObservableProperty]
    public partial IngredientDetailModel? Ingredient { get; set; }

    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();

        Ingredient = await ingredientsClient.GetIngredientByIdAsync(Id);
    }
}