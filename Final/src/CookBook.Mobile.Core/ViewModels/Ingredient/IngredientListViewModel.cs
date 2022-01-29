using CookBook.Common.Models;
using CookBook.Mobile.Core.Api;
using CookBook.Mobile.Core.Factories;
using CookBook.Mobile.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CookBook.Mobile.Core.ViewModels.Ingredient
{
    public class IngredientListViewModel : ViewModelBase
    {
        private readonly INavigationService navigationService;
        private readonly IApiClient apiClient;
        public ICollection<IngredientListModel> Items { get; set; }

        public ICommand NavigateToDetailViewCommand { get; set; }

        public IngredientListViewModel(
            INavigationService navigationService,
            ICommandFactory commandFactory,
            IApiClient apiClient)
        {
            this.navigationService = navigationService;
            this.apiClient = apiClient;

            NavigateToDetailViewCommand = commandFactory.CreateCommand<Guid>(NavigateToDetailViewAsync);
        }

        public override async Task OnAppearingAsync()
        {
            await base.OnAppearingAsync();

            Items = await apiClient.IngredientsAsync();
        }

        private async Task NavigateToDetailViewAsync(Guid id)
        {
            await navigationService.PushAsync<IngredientDetailViewModel, Guid>(id);
        }
    }
}