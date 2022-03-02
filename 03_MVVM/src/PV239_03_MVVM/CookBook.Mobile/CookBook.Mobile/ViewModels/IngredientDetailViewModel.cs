using CookBook.Mobile.Commands;
using CookBook.Mobile.Factory;
using CookBook.Mobile.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CookBook.Mobile.ViewModels
{
    public class IngredientDetailViewModel : ViewModelBase
    {
        public IngredientDetailModel Data { get; set; } = new IngredientDetailModel
        {
            Name = "Vejce",
            Description = "Popis vajec 2",
            ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/5e/Chicken_egg_2009-06-04.jpg/428px-Chicken_egg_2009-06-04.jpg"
        };

        public ICommand EditCommand { get; set; }

        public IngredientDetailViewModel()
        {
            Task.Run(async () =>
            {
                await Task.Delay(3000);
                Data.Description = "Test";

                //Data = new IngredientDetailModel
                //{
                //    Description = "Description new"
                //};
            });

            var commandFactory = new CommandFactory();

            EditCommand = commandFactory.CreateCommand<string>(Edit, (description) => CanEdit(description));
        }

        private void Edit(string description)
        {
            Data.Description = description;
        }

        private bool CanEdit(string description)
        {
            return true;
        }
    }
}