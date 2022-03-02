using CookBook.Mobile.Commands;
using System;
using System.Linq.Expressions;
using System.Windows.Input;

namespace CookBook.Mobile.Factory
{
    public class CommandFactory
    {
        public ICommand CreateCommand(Action execute, Expression<Func<bool>>? canExecute = null)
        {
            return new Command(execute, canExecute?.Compile());
        }

        public ICommand CreateCommand<T>(Action<T> execute, Expression<Func<T, bool>>? canExecute = null)
        {
            return new Command<T>(execute, canExecute?.Compile());
        }
    }
}