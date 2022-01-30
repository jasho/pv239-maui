using CookBook.Common.Models;
using CookBook.Mobile.Core.Factories;
using CookBook.Mobile.Core.Services.Interfaces;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using CookBook.Mobile.Core.Api;

namespace CookBook.Mobile.Core.ViewModels.Ingredient
{
    public class IngredientEditViewModel : ViewModelBase<Guid>
    {
        private readonly INavigationService navigationService;
        private readonly IIngredientsClient ingredientsClient;

        public IngredientDetailModel Item { get; set; }

        public ICommand SaveCommand { get; set; }

        public IngredientEditViewModel(
            INavigationService navigationService,
            ICommandFactory commandFactory,
            IIngredientsClient ingredientsClient)
        {
            this.navigationService = navigationService;
            this.ingredientsClient = ingredientsClient;

            SaveCommand = commandFactory.CreateCommand(SaveAsync);
        }

        public override async Task OnAppearingAsync()
        {
            await base.OnAppearingAsync();

            Item = await ingredientsClient.GetByIdAsync(ViewModelParameter);
        }

        private async Task SaveAsync()
        {
            await ingredientsClient.UpdateAsync(Item);
            await navigationService.PopAsync();
        }
    }
}