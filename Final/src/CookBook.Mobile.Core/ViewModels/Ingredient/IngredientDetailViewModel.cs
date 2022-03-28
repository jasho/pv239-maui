using CookBook.Common.Models;
using CookBook.Mobile.Core.Api;
using CookBook.Mobile.Core.Factories;
using CookBook.Mobile.Core.Repositories.Interfaces;
using CookBook.Mobile.Core.Services.Interfaces;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CookBook.Mobile.Core.ViewModels.Ingredient
{
    public class IngredientDetailViewModel : ViewModelBase<Guid>
    {
        private readonly INavigationService navigationService;
        private readonly IIngredientRepository ingredientRepository;

        public IngredientDetailModel Item { get; set; } = null!;

        public ICommand NavigateToEditViewCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public IngredientDetailViewModel(
            INavigationService navigationService,
            ICommandFactory commandFactory,
            IIngredientRepository ingredientRepository)
        {
            this.navigationService = navigationService;
            this.ingredientRepository = ingredientRepository;
            NavigateToEditViewCommand = commandFactory.CreateCommand(NavigateToEditViewAsync);
            DeleteCommand = commandFactory.CreateCommand(DeleteAsync);
        }

        public override async Task OnAppearingAsync()
        {
            await base.OnAppearingAsync();

            Item = await ingredientRepository.GetByIdAsync(ViewModelParameter);
        }

        private async Task NavigateToEditViewAsync()
        {
            await navigationService.PushAsync<IngredientEditViewModel, Guid?>(ViewModelParameter);
        }

        private async Task DeleteAsync()
        {
            await ingredientRepository.DeleteAsync(ViewModelParameter);
            await navigationService.PopAsync();
        }
    }
}