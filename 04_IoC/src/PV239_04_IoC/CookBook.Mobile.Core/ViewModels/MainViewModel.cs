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

        public ICommand NavigateToIngredientListViewCommand { get; set; }

        public MainViewModel(
            INavigationService navigationService,
            ICommandFactory commandFactory)
        {
            this.navigationService = navigationService;

            NavigateToIngredientListViewCommand = commandFactory.CreateCommand(NavigateToIngredientListAsync);
        }

        public override async Task OnAppearingAsync()
        {
        }

        private async Task NavigateToIngredientListAsync()
        {
            await navigationService.PushAsync<IngredientListViewModel>();
        }
    }
}