using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CookBook.Maui.Clients;
using CookBook.Maui.Clients.Interfaces;
using CookBook.Maui.Models;
using CookBook.Mobile.Enums;
using System.Collections.ObjectModel;

namespace CookBook.Maui.ViewModels.Recipe;

public partial class RecipeListViewModel : ViewModelBase
{
    private IRecipesClient recipesClient;

    public RecipeListViewModel(IRecipesClient recipesClient)
    {
        this.recipesClient = recipesClient;

        LoadData();
    }

    private async Task LoadData()
    {
        Items = await recipesClient.GetRecipesAllAsync();
    }

    [ObservableProperty]
    public partial ICollection<RecipeListModel> Items { get; set; } = [];

    [RelayCommand]
    private async Task GoToDetailAsync(Guid id)
    {
        await Shell.Current.GoToAsync("./detail");
    }
}