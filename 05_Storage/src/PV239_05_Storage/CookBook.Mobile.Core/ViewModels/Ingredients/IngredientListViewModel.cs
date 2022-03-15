using CookBook.Mobile.Core.Factories;
using CookBook.Mobile.Core.Models.Ingredient;
using CookBook.Mobile.Core.Repositories;
using CookBook.Mobile.Core.Services;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CookBook.Mobile.Core.ViewModels.Ingredients
{
    public class IngredientListViewModel : ViewModelBase
    {
        private readonly IIngredientRepository ingredientRepository;
        private readonly INavigationService navigationService;

        public ObservableCollection<IngredientListModel> Items { get; set; }

        public ICommand NavigateToDetailViewCommand { get; set; }
        public ICommand NavigateToCreateViewCommand { get; set; }

        public IngredientListViewModel(
            IIngredientRepository ingredientRepository,
            ICommandFactory commandFactory,
            INavigationService navigationService)
        {
            this.ingredientRepository = ingredientRepository;
            this.navigationService = navigationService;

            NavigateToDetailViewCommand = commandFactory.CreateCommand<Guid>(NavigateToDetailAsync);
        }

        public override async Task OnAppearingAsync()
        {
            await base.OnAppearingAsync();

            Items = await ingredientRepository.GetAllAsync();
        }

        private async Task NavigateToDetailAsync(Guid id)
        {
            await navigationService.PushAsync<IngredientDetailViewModel, Guid>(viewModelParameter: id);
        }

        private async Task NavigateToCreateViewAsync()
        {
        }
    }
}