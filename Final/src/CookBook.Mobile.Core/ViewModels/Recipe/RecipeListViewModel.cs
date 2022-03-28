using CookBook.Common.Models;
using CookBook.Mobile.Core.Api;
using CookBook.Mobile.Core.Enums;
using CookBook.Mobile.Core.Factories;
using CookBook.Mobile.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CookBook.Mobile.Core.ViewModels.Recipe
{
    public class RecipeListViewModel : ViewModelBase
    {
        private readonly INavigationService navigationService;
        private readonly IRecipesClient recipesClient;

        public ICollection<RecipeListModel> Items { get; set; }

        public ICommand NavigateToDetailViewCommand { get; set; }
        public ICommand NavigateToCreateViewCommand { get; set; }

        public RecipeListViewModel(
            INavigationService navigationService,
            ICommandFactory commandFactory,
            IRecipesClient recipesClient)
        {
            this.navigationService = navigationService;
            this.recipesClient = recipesClient;

            NavigateToDetailViewCommand = commandFactory.CreateCommand<Guid>(NavigateToDetailViewAsync);
            NavigateToCreateViewCommand = commandFactory.CreateCommand(NavigateToCreateViewAsync);
        }

        public override async Task OnAppearingAsync()
        {
            State = AppState.Loading;
            
            // TODO: demo purpose only
            await Task.Delay(2000);

            await base.OnAppearingAsync();
            Items = await recipesClient.GetRecipesAllAsync();
            
            // TODO: demo - Empty
            //Items.Clear();

            State = Items.Any() 
                ? AppState.None
                : AppState.Empty;
        }

        private async Task NavigateToDetailViewAsync(Guid id)
        {
            await navigationService.PushAsync<RecipeDetailViewModel, Guid>(id);
        }

        private async Task NavigateToCreateViewAsync()
        {
            await navigationService.PushAsync<RecipeEditViewModel, Guid?>();
        }
    }
}