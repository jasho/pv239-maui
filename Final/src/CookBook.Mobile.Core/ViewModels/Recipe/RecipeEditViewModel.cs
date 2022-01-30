using CookBook.Common.Models;
using CookBook.Mobile.Core.Api;
using CookBook.Mobile.Core.Factories;
using CookBook.Mobile.Core.Services.Interfaces;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CookBook.Mobile.Core.ViewModels.Recipe
{
    public class RecipeEditViewModel : ViewModelBase<Guid>
    {
        private readonly INavigationService navigationService;
        private readonly IRecipesClient recipesClient;

        public RecipeDetailModel Item { get; set; }

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

            Item = await recipesClient.GetRecipeByIdAsync(ViewModelParameter);
        }

        private async Task SaveAsync()
        {
            await recipesClient.UpdateRecipeAsync(Item);
            await navigationService.PopAsync();
        }
    }
}