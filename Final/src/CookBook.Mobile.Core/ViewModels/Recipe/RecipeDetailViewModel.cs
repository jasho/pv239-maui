using CookBook.Common.Models;
using CookBook.Mobile.Core.Api;
using CookBook.Mobile.Core.Factories;
using CookBook.Mobile.Core.Services.Interfaces;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CookBook.Mobile.Core.ViewModels.Recipe
{
    public class RecipeDetailViewModel : ViewModelBase<Guid>
    {
        private readonly INavigationService navigationService;
        private readonly IRecipesClient recipesClient;

        public RecipeDetailModel Item { get; set; }

        public ICommand NavigateToEditViewCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public RecipeDetailViewModel(
            INavigationService navigationService,
            ICommandFactory commandFactory,
            IRecipesClient recipesClient)
        {
            this.navigationService = navigationService;
            this.recipesClient = recipesClient;

            NavigateToEditViewCommand = commandFactory.CreateCommand(NavigateToEditViewAsync);
            DeleteCommand = commandFactory.CreateCommand(DeleteAsync);
        }

        public override async Task OnAppearingAsync()
        {
            await base.OnAppearingAsync();

            Item = await recipesClient.GetRecipeByIdAsync(ViewModelParameter);
        }

        private async Task NavigateToEditViewAsync()
        {
        }

        private async Task DeleteAsync()
        {
        }
    }
}