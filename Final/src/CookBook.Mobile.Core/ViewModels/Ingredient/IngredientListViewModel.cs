using CookBook.Common.Models;
using CookBook.Mobile.Core.Factories;
using CookBook.Mobile.Core.Services.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CookBook.Mobile.Core.ViewModels.Ingredient
{
    public class IngredientListViewModel : ViewModelBase
    {
        private readonly INavigationService navigationService;
        public ObservableCollection<IngredientListModel> Items { get; set; }

        public ICommand NavigateToDetailViewCommand { get; set; }

        public IngredientListViewModel(
            INavigationService navigationService,
            ICommandFactory commandFactory)
        {
            this.navigationService = navigationService;

            NavigateToDetailViewCommand = commandFactory.CreateCommand<Guid>(NavigateToDetailViewAsync);
        }

        public override async Task OnAppearingAsync()
        {
            await base.OnAppearingAsync();

            Items = new ObservableCollection<IngredientListModel>
            {
                new (Guid.NewGuid(), "Vejce", "https://upload.wikimedia.org/wikipedia/commons/thumb/5/5e/Chicken_egg_2009-06-04.jpg/428px-Chicken_egg_2009-06-04.jpg"),
                new (Guid.NewGuid(), "Cibule", "https://upload.wikimedia.org/wikipedia/commons/thumb/2/25/Onion_on_White.JPG/480px-Onion_on_White.JPG"),
            };
        }

        private async Task NavigateToDetailViewAsync(Guid id)
        {
            await navigationService.PushAsync<IngredientDetailViewModel, Guid>(id);
        }
    }
}