using CookBook.Mobile.Core.Commands;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CookBook.Mobile.Core.Factories
{
    public interface ICommandFactory
    {
        ICommand CreateCommand(Action execute, Expression<Func<bool>>? canExecute = null);
        ICommand CreateCommand<T>(Action<T> execute, Expression<Func<T, bool>>? canExecute = null);

        AsyncCommand CreateCommand(Func<Task> execute, Func<bool>? canExecute = null,
            Action<Exception>? onException = null, bool continueOnCapturedContext = false);
        AsyncCommand<T> CreateCommand<T>(Func<T, Task> execute, Func<T, bool>? canExecute = null,
            Action<Exception>? onException = null, bool continueOnCapturedContext = false);
    }
}