using PV239_05_Storage.Core.Commands;
using PV239_05_Storage.Core.Factories.Interfaces;
using System;
using System.Linq.Expressions;
using System.Windows.Input;

namespace PV239_05_Storage.Core.Factories
{
    public class CommandFactory : ICommandFactory
    {
        public ICommand CreateCommand(Action execute, Expression<Func<bool>> canExecute = null)
        {
            return new Command(execute, canExecute?.Compile());
        }

        public ICommand CreateCommand<T>(Action<T> execute, Expression<Func<T, bool>> canExecute = null)
        {
            return new Command<T>(execute, canExecute?.Compile());
        }
    }
}