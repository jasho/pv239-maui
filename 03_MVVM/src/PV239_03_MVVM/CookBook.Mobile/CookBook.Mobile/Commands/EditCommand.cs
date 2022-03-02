using System;
using System.Windows.Input;

namespace CookBook.Mobile.Commands
{
    public class EditCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
        }

        public event EventHandler CanExecuteChanged;
    }
}