using CookBook.Common.Models;
using CookBook.Mobile.Core.Api;
using CookBook.Mobile.Core.Factories;
using CookBook.Mobile.Core.Services.Interfaces;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CookBook.Mobile.Core.ViewModels.Ingredient
{
    public class IngredientEditViewModel : ViewModelBase<Guid?>
    {
        private readonly INavigationService navigationService;
        private readonly IIngredientsClient ingredientsClient;

        public IngredientDetailModel Item { get; set; } = null!;

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

            Item = ViewModelParameter is null
                ? new IngredientDetailModel(null, string.Empty, string.Empty, null)
                : await ingredientsClient.GetIngredientByIdAsync(ViewModelParameter.Value);
        }

        private async Task SaveAsync()
        {
            if (ViewModelParameter is null)
            {
                await ingredientsClient.CreateIngredientAsync(Item);
            }
            else
            {
                await ingredientsClient.UpdateIngredientAsync(Item);
            }

            await navigationService.PopAsync();
        }
    }
}