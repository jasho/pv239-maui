using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CookBook.Mobile.Core.Commands
{
    public class AsyncCommand : ICommand
    {
        private readonly Func<Task> execute;
        private readonly Action<Exception>? onException;
        private readonly bool continueOnCapturedContext;
        private readonly Func<bool> canExecute;

        public AsyncCommand(
            Func<Task> execute,
            Func<bool>? canExecute,
            Action<Exception>? onException,
            bool continueOnCapturedContext)
        {
            this.execute = execute;
            this.onException = onException;
            this.continueOnCapturedContext = continueOnCapturedContext;
            this.canExecute = canExecute ?? (() => true);
        }

        public bool CanExecute(object parameter)
            => canExecute.Invoke();

        public void Execute(object parameter)
            => ExecuteAsync();

        public event EventHandler? CanExecuteChanged;

        public Task ExecuteAsync()
            => execute.Invoke();
    }

    public class AsyncCommand<T> : ICommand
    {
        private readonly Func<T, Task> execute;
        private readonly Action<Exception>? onException;
        private readonly bool continueOnCapturedContext;
        private readonly Func<T, bool> canExecute;

        public AsyncCommand(
            Func<T, Task> execute,
            Func<T, bool>? canExecute,
            Action<Exception>? onException,
            bool continueOnCapturedContext)
        {
            this.execute = execute;
            this.onException = onException;
            this.continueOnCapturedContext = continueOnCapturedContext;
            this.canExecute = canExecute ?? (T => true);
        }

        public bool CanExecute(object parameter)
            => (parameter is T typedParameter) && canExecute.Invoke(typedParameter);

        public void Execute(object parameter)
        {
            if (parameter is T typedParameter)
            {
                ExecuteAsync(typedParameter);
            }
        }

        public event EventHandler? CanExecuteChanged;

        public Task ExecuteAsync(T parameter)
            => execute.Invoke(parameter);
    }
}