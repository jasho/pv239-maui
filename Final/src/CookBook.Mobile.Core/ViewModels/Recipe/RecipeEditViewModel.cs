using CookBook.Common.Enums;
using CookBook.Common.Models;
using CookBook.Mobile.Core.Api;
using CookBook.Mobile.Core.Factories;
using CookBook.Mobile.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CookBook.Mobile.Core.ViewModels.Recipe
{
    public class RecipeEditViewModel : ViewModelBase<Guid?>
    {
        private readonly INavigationService navigationService;
        private readonly IRecipesClient recipesClient;

        public RecipeDetailModel Item { get; set; } = null!;

        public ICommand SaveCommand { get; set; }

        public RecipeEditViewModel(
            INavigationService navigationService,
            ICommandFactory commandFactory,
            IRecipesClient recipesClient)
        {
            this.navigationService = navigationService;
            this.recipesClient = recipesClient;

            SaveCommand = commandFactory.CreateCommand(SaveAsync);
        }

        public override async Task OnAppearingAsync()
        {
            await base.OnAppearingAsync();

            Item = ViewModelParameter is null
                ? new RecipeDetailModel(null, string.Empty, string.Empty, TimeSpan.Zero, FoodType.Unknown, new List<RecipeDetailIngredientModel>(), null)
                : await recipesClient.GetRecipeByIdAsync(ViewModelParameter.Value);
        }

        private async Task SaveAsync()
        {
            try
            {
                if (ViewModelParameter is null)
                {
                    await recipesClient.CreateRecipeAsync(Item);
                }
                else
                {
                    await recipesClient.UpdateRecipeAsync(Item);
                }

                await navigationService.PopAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}