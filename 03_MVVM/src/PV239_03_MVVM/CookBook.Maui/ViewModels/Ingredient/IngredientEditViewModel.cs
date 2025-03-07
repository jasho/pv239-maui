using CookBook.Maui.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace CookBook.Maui.ViewModels.Ingredient
{
    class IngredientEditViewModel : INotifyPropertyChanged
    {
        private IngredientDetailModel ingredient = new IngredientDetailModel
        {
            Id = Guid.NewGuid(),
            Name = "John Doe",
            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
        };

        public IngredientDetailModel Ingredient
        {
            get => ingredient;
            set
            {
                if (ingredient != value)
                {
                    ingredient = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand UpdatePersonCommand { get; set; }

        //public PersonModel Person { get; set; }

        public IngredientEditViewModel()
        {
            UpdatePersonCommand = new Command(UpdatePerson, CanUpdatePerson);
        }

        private void UpdatePerson()
        {
            Ingredient.Name = "John Doe Updated";
        }

        private bool CanUpdatePerson()
        {
            return true;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            ArgumentNullException.ThrowIfNull(e);

            PropertyChanged?.Invoke(this, e);
        }
    }
}
