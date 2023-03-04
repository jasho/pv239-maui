using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CookBook.Mobile.Clients;
using CookBook.Mobile.Enums;
using CookBook.Mobile.Models;
using System.Collections.ObjectModel;

namespace CookBook.Mobile.ViewModels.Recipe;

public partial class RecipeListViewModel : ViewModelBase
{
    private readonly IRecipesClient recipesClient;

    [ObservableProperty]
    private ICollection<RecipeListModel>? items;

    public RecipeListViewModel(IRecipesClient recipesClient)
    {
        this.recipesClient = recipesClient;
    }

    public override async Task OnAppearingAsync()
    {
        await base.OnAppearingAsync();

        Items = await recipesClient.GetRecipesAllAsync();
    }

    [RelayCommand]
    private void GoToDetail(Guid id)
    {
    }

    [RelayCommand]
    private void GoToCreate()
    {
    }
}