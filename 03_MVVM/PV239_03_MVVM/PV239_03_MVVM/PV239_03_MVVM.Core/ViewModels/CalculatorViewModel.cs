using PV239_03_MVVM.Core.Commands;
using PV239_03_MVVM.Core.Models;
using System.Windows.Input;

namespace PV239_03_MVVM.Core.ViewModels
{
    public class CalculatorViewModel
    {
        public CalculatorProblemModel CalculatorProblem { get; set; }
            = new CalculatorProblemModel
            {
                Operand1 = 1,
                Operand2 = 2,
                Result = 3
            };

        public ICommand AddCommand { get; set; }

        public CalculatorViewModel()
        {
            AddCommand = new Command(Add, () => true);
        }

        public void Add()
        {
            CalculatorProblem.Result =
                CalculatorProblem.Operand1 + CalculatorProblem.Operand2;
        }
    }
}