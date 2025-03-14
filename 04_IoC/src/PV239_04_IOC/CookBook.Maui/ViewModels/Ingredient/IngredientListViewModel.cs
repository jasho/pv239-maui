using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CookBook.Maui.Clients.Interfaces;
using CookBook.Maui.Models;
using CookBook.Maui.ViewModels.Ingredient;

namespace CookBook.Maui.ViewModels;

public partial class IngredientListViewModel(IIngredientsClient ingredientsClient)
    : ViewModelBase
{
    [ObservableProperty]
    public partial ICollection<IngredientListModel> Items { get; set; }

    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();

        Items = await ingredientsClient.GetIngredientsAllAsync();
    }

    [RelayCommand]
    public async Task GoToDetailAsync(Guid id)
    {
        await Shell.Current.GoToAsync("./detail", new Dictionary<string, object>
        {
            [nameof(IngredientDetailViewModel.Id)] = id
        });
    }

    [RelayCommand]
    public async Task GoToCreateAsync()
    {
        // TODO add navigation to ingredient edit page
        //await Shell.Current.GoToAsync("");
    }
}
