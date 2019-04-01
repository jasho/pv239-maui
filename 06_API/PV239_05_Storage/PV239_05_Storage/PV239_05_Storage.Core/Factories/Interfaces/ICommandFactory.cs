using System;
using System.Linq.Expressions;
using System.Windows.Input;

namespace PV239_05_Storage.Core.Factories.Interfaces
{
    public interface ICommandFactory : IFactory
    {
        ICommand CreateCommand(Action execute, Expression<Func<bool>> canExecute = null);
        ICommand CreateCommand<T>(Action<T> execute, Expression<Func<T, bool>> canExecute = null);
    }
}