using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CookBook.Mobile.Clients;
using CookBook.Mobile.Models;

namespace CookBook.Mobile.ViewModels.Ingredient;

public partial class IngredientListViewModel : ViewModelBase
{
    private readonly IIngredientsClient ingredientsClient;

    [ObservableProperty]
    private ICollection<IngredientListModel> items = new List<IngredientListModel>();

    public IngredientListViewModel(IIngredientsClient ingredientsClient)
    {
        this.ingredientsClient = ingredientsClient;
    }

    public override async Task OnAppearingAsync()
    {
        await base.OnAppearingAsync();

        Items = await ingredientsClient.GetIngredientsAllAsync();
    }

    [RelayCommand]
    private void GoToDetail(Guid id)
    {
        Shell.Current.GoToAsync("detail", new Dictionary<string, object>
        {
            [nameof(IngredientDetailViewModel.Id)] = id
        });
    }

    [RelayCommand]
    private void GoToCreate()
    {
    }

    [RelayCommand]
    private void GoToEdit(Guid id)
    {
    }
}