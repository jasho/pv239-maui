using CookBook.Mobile.Core.Factories;
using CookBook.Mobile.Core.Services.Interfaces;
using CookBook.Mobile.Core.ViewModels.Ingredient;
using CookBook.Mobile.Core.ViewModels.Recipe;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CookBook.Mobile.Core.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly INavigationService navigationService;

        public ICommand NavigateToSettingsViewCommand { get; set; }
        public ICommand NavigateToIngredientListViewCommand { get; set; }
        public ICommand NavigateToRecipeListViewCommand { get; set; }

        public MainViewModel(
            INavigationService navigationService,
            ICommandFactory commandFactory)
        {
            this.navigationService = navigationService;

            NavigateToSettingsViewCommand = commandFactory.CreateCommand(NavigateToSettingsViewAsync);
            NavigateToIngredientListViewCommand = commandFactory.CreateCommand(NavigateToIngredientListAsync);
            NavigateToRecipeListViewCommand = commandFactory.CreateCommand(NavigateToRecipeListViewAsync);
        }

        private async Task NavigateToSettingsViewAsync()
        {
            await navigationService.PushAsync<SettingsViewModel>();
        }

        private async Task NavigateToIngredientListAsync()
        {
            await navigationService.PushAsync<IngredientListViewModel>();
        }

        private async Task NavigateToRecipeListViewAsync()
        {
            await navigationService.PushAsync<RecipeListViewModel>();
        }
    }
}