using CookBook.Mobile.Core.Entities;
using CookBook.Mobile.Core.Factories;
using CookBook.Mobile.Core.Services;
using CookBook.Mobile.Core.ViewModels.Ingredients;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CookBook.Mobile.Core.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly INavigationService navigationService;
        private readonly IDatabaseService databaseService;

        public ICommand NavigateToSettingsViewCommand { get; set; }
        public ICommand NavigateToIngredientListViewCommand { get; set; }

        public MainViewModel(
            INavigationService navigationService,
            ICommandFactory commandFactory,
            IDatabaseService databaseService)
        {
            this.navigationService = navigationService;
            this.databaseService = databaseService;

            NavigateToSettingsViewCommand = commandFactory.CreateCommand(NavigateToSettingsViewAsync);
            NavigateToIngredientListViewCommand = commandFactory.CreateCommand(NavigateToIngredientListAsync);
        }
        private async Task NavigateToSettingsViewAsync()
        {
            await navigationService.PushAsync<SettingsViewModel>();
        }

        public override async Task OnAppearingAsync()
        {
            var createTableResult = await databaseService.CreateTableAsync<IngredientEntity>();
        }

        private async Task NavigateToIngredientListAsync()
        {
            await navigationService.PushAsync<IngredientListViewModel>();
        }
    }
}