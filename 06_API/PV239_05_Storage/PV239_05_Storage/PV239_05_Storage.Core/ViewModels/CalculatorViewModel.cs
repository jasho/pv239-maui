using System;
using System.Windows.Input;
using PV239_05_Storage.Core.Commands;
using PV239_05_Storage.Core.Models;
using PV239_05_Storage.Core.ViewModels.Base;

namespace PV239_05_Storage.Core.ViewModels
{
    public class CalculatorViewModel : ViewModelBase
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

        private void Execute(int obj)
        {
            throw new NotImplementedException();
        }

        public void Add()
        {
            CalculatorProblem.Result =
                CalculatorProblem.Operand1 + CalculatorProblem.Operand2;
        }
    }
}