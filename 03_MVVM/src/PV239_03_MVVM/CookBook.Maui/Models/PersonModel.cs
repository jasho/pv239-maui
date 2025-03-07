using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CookBook.Maui.Models
{
    class PersonModel : INotifyPropertyChanged
    {
        public string Name
        {
            get => field;
            set
            {
                if(field != value)
                {
                    field = value;
                    OnPropertyChanged();
                }
            }
        }

        //public string Name { get; set; }
        public int Age { get; set; }

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
