using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PV239_06_API.Core.Models
{
    public class CalculatorProblemModel : INotifyPropertyChanged
    {
        public int Operand1 { get; set; }
        public int Operand2 { get; set; }
        public int Result { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}