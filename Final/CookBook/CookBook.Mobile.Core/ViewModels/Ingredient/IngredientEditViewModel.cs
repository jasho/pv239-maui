using CookBook.Common.Models;
using CookBook.Mobile.Core.Factories;
using CookBook.Mobile.Core.Services.Interfaces;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CookBook.Mobile.Core.ViewModels.Ingredient
{
    public class IngredientEditViewModel : ViewModelBase<Guid>
    {
        private readonly INavigationService navigationService;

        public IngredientDetailModel Item { get; set; }

        public ICommand SaveCommand { get; set; }

        public IngredientEditViewModel(
            INavigationService navigationService,
            ICommandFactory commandFactory)
        {
            this.navigationService = navigationService;

            SaveCommand = commandFactory.CreateCommand(SaveAsync);
        }

        public override async Task OnAppearingAsync()
        {
            await base.OnAppearingAsync();

            Item = new IngredientDetailModel(ViewModelParameter, "Vejce", "Prostě vejce", "https://upload.wikimedia.org/wikipedia/commons/thumb/5/5e/Chicken_egg_2009-06-04.jpg/428px-Chicken_egg_2009-06-04.jpg");
        }

        private async Task SaveAsync()
        {
            await navigationService.PopAsync();
        }
    }
}