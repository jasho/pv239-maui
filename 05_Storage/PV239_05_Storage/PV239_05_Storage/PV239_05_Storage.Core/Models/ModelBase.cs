using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PV239_05_Storage.Core.Models
{
    public class ModelBase : INotifyPropertyChanged
    {
        public int Id { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}