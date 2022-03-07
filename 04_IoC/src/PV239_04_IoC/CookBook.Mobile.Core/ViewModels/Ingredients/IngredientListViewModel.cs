using CookBook.Mobile.Core.Factories;
using CookBook.Mobile.Core.Models.Ingredient;
using CookBook.Mobile.Core.Repositories;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CookBook.Mobile.Core.ViewModels.Ingredients
{
    public class IngredientListViewModel : ViewModelBase
    {
        private readonly IIngredientRepository ingredientRepository;

        public ObservableCollection<IngredientListModel> Items { get; set; }

        public ICommand NavigateToDetailViewCommand { get; set; }
        public ICommand NavigateToCreateViewCommand { get; set; }

        public IngredientListViewModel(
            IIngredientRepository ingredientRepository,
            ICommandFactory commandFactory)
        {
            this.ingredientRepository = ingredientRepository;

            NavigateToDetailViewCommand = commandFactory.CreateCommand(NavigateToDetailAsync);
            NavigateToCreateViewCommand = commandFactory.CreateCommand(NavigateToCreateViewAsync);
        }

        public override async Task OnAppearingAsync()
        {
            await base.OnAppearingAsync();

            Items = ingredientRepository.GetAll();
        }

        private async Task NavigateToDetailAsync()
        {
        }

        private async Task NavigateToCreateViewAsync()
        {
        }
    }
}