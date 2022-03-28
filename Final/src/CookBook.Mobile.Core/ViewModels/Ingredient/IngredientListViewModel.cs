using CookBook.Common.Models;
using CookBook.Mobile.Core.Factories;
using CookBook.Mobile.Core.Repositories.Interfaces;
using CookBook.Mobile.Core.Services.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CookBook.Mobile.Core.ViewModels.Ingredient
{
    public class IngredientListViewModel : ViewModelBase
    {
        private readonly INavigationService navigationService;
        private readonly IIngredientRepository ingredientRepository;

        public ObservableCollection<IngredientListModel> Items { get; set; }

        public ICommand NavigateToDetailViewCommand { get; set; }
        public ICommand NavigateToCreateViewCommand { get; set; }

        public IngredientListViewModel(
            INavigationService navigationService,
            ICommandFactory commandFactory,
            IIngredientRepository ingredientRepository)
        {
            this.navigationService = navigationService;
            this.ingredientRepository = ingredientRepository;
            NavigateToDetailViewCommand = commandFactory.CreateCommand<Guid>(NavigateToDetailViewAsync);
            NavigateToCreateViewCommand = commandFactory.CreateCommand(NavigateToCreateViewAsync);
        }

        public override async Task OnAppearingAsync()
        {
            await base.OnAppearingAsync();

            Items = await ingredientRepository.GetAllAsync();
        }

        private async Task NavigateToDetailViewAsync(Guid id)
        {
            await navigationService.PushAsync<IngredientDetailViewModel, Guid>(id);
        }

        private async Task NavigateToCreateViewAsync()
        {
            await navigationService.PushAsync<IngredientEditViewModel, Guid?>();
        }
    }
}