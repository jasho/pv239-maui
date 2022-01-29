using System.Threading.Tasks;
using System.Windows.Input;
using CookBook.Mobile.Core.Factories;
using CookBook.Mobile.Core.Services.Interfaces;
using CookBook.Mobile.Core.ViewModels.Ingredient;

namespace CookBook.Mobile.Core.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly INavigationService navigationService;

        public ICommand NavigateToIngredientListViewCommand { get; set; }

        public MainViewModel(
            INavigationService navigationService,
            ICommandFactory commandFactory)
        {
            this.navigationService = navigationService;

            NavigateToIngredientListViewCommand = commandFactory.CreateCommand(NavigateToIngredientListAsync);
        }

        private async Task NavigateToIngredientListAsync()
        {
            await navigationService.PushAsync<IngredientListViewModel>();
        }
    }
}