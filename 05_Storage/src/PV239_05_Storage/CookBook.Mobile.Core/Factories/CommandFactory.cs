using CookBook.Mobile.Core.Commands;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CookBook.Mobile.Core.Factories
{
    public class CommandFactory : ICommandFactory
    {
        public ICommand CreateCommand(Action execute, Expression<Func<bool>>? canExecute = null)
        {
            return new Command(execute, canExecute?.Compile());
        }

        public ICommand CreateCommand<T>(Action<T> execute, Expression<Func<T, bool>>? canExecute = null)
        {
            return new Command<T>(execute, canExecute?.Compile());
        }

        public AsyncCommand CreateCommand(Func<Task> execute, Func<bool>? canExecute = null, Action<Exception>? onException = null,
            bool continueOnCapturedContext = false)
        {
            return new AsyncCommand(execute, canExecute, onException, continueOnCapturedContext);
        }

        public AsyncCommand<T> CreateCommand<T>(Func<T, Task> execute, Func<T, bool>? canExecute = null, Action<Exception>? onException = null,
            bool continueOnCapturedContext = false)
        {
            return new AsyncCommand<T>(execute, canExecute, onException, continueOnCapturedContext);
        }
    }
}