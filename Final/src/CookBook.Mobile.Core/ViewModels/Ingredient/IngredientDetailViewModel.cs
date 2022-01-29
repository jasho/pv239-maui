using CookBook.Common.Models;
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

        public IngredientDetailModel Item { get; set; }

        public ICommand NavigateToEditViewCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public IngredientDetailViewModel(
            INavigationService navigationService,
            ICommandFactory commandFactory)
        {
            this.navigationService = navigationService;

            NavigateToEditViewCommand = commandFactory.CreateCommand(NavigateToEditViewAsync);
            DeleteCommand = commandFactory.CreateCommand(DeleteAsync);
        }

        public override async Task OnAppearingAsync()
        {
            await base.OnAppearingAsync();

            Item = new IngredientDetailModel(ViewModelParameter, "Vejce", "Prostě vejce", "https://upload.wikimedia.org/wikipedia/commons/thumb/5/5e/Chicken_egg_2009-06-04.jpg/428px-Chicken_egg_2009-06-04.jpg");
        }

        private async Task NavigateToEditViewAsync()
        {
            await navigationService.PushAsync<IngredientEditViewModel, Guid>(ViewModelParameter);
        }

        private async Task DeleteAsync()
        {
            await navigationService.PopAsync();
        }
    }
}