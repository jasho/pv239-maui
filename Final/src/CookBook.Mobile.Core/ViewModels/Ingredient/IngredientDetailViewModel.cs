using CookBook.Common.Models;
using CookBook.Mobile.Core.Api;
using CookBook.Mobile.Core.Factories;
using CookBook.Mobile.Core.Services.Interfaces;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CookBook.Mobile.Core.ViewModels.Ingredient
{
    public class IngredientDetailViewModel : ViewModelBase<Guid>
    {
        private readonly INavigationService navigationService;
        private readonly IIngredientsClient ingredientsClient;

        public IngredientDetailModel Item { get; set; } = null!;

        public ICommand NavigateToEditViewCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public IngredientDetailViewModel(
            INavigationService navigationService,
            ICommandFactory commandFactory,
            IIngredientsClient ingredientsClient)
        {
            this.navigationService = navigationService;
            this.ingredientsClient = ingredientsClient;

            NavigateToEditViewCommand = commandFactory.CreateCommand(NavigateToEditViewAsync);
            DeleteCommand = commandFactory.CreateCommand(DeleteAsync);
        }

        public override async Task OnAppearingAsync()
        {
            await base.OnAppearingAsync();

            Item = await ingredientsClient.GetIngredientByIdAsync(ViewModelParameter);
        }

        private async Task NavigateToEditViewAsync()
        {
            await navigationService.PushAsync<IngredientEditViewModel, Guid?>(ViewModelParameter);
        }

        private async Task DeleteAsync()
        {
            await ingredientsClient.DeleteIngredientAsync(ViewModelParameter);
            await navigationService.PopAsync();
        }
    }
}