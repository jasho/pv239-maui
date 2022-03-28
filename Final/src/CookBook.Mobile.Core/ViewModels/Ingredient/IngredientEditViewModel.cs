using CookBook.Common.Models;
using CookBook.Mobile.Core.Factories;
using CookBook.Mobile.Core.Repositories.Interfaces;
using CookBook.Mobile.Core.Services.Interfaces;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CookBook.Mobile.Core.ViewModels.Ingredient
{
    public class IngredientEditViewModel : ViewModelBase<Guid?>
    {
        private readonly INavigationService navigationService;
        private readonly IIngredientRepository ingredientRepository;

        public IngredientDetailModel Item { get; set; } = null!;

        public ICommand SaveCommand { get; set; }

        public IngredientEditViewModel(
            INavigationService navigationService,
            ICommandFactory commandFactory,
            IIngredientRepository ingredientRepository)
        {
            this.navigationService = navigationService;
            this.ingredientRepository = ingredientRepository;

            SaveCommand = commandFactory.CreateCommand(SaveAsync);
        }

        public override async Task OnAppearingAsync()
        {
            await base.OnAppearingAsync();

            Item = ViewModelParameter is null
                ? new IngredientDetailModel(null, string.Empty, string.Empty, null)
                : await ingredientRepository.GetByIdAsync(ViewModelParameter.Value);
        }

        private async Task SaveAsync()
        {
            if (ViewModelParameter is null)
            {
                await ingredientRepository.CreateAsync(Item);
            }
            else
            {
                await ingredientRepository.UpdateAsync(Item);
            }

            await navigationService.PopAsync();
        }
    }
}