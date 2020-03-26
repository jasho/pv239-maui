using PV239_06_API.Core.Api;
using PV239_06_API.Core.Factories.Interfaces;
using PV239_06_API.Core.Services.Interfaces;
using PV239_06_API.Core.ViewModels.Base;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PV239_06_API.Core.ViewModels
{
    public class TodoDetailViewModel : ViewModelBase<Guid?>
    {
        private readonly INavigationService navigationService;
        private readonly ITodoClient todoClient;
        public TodoItemDto TodoItem { get; set; }

        public ICommand SaveCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public TodoDetailViewModel(
            Guid? viewModelParameter,
            ICommandFactory commandFactory,
            INavigationService navigationService,
            ITodoClient todoClient)
            : base(viewModelParameter)
        {
            this.navigationService = navigationService;
            this.todoClient = todoClient;

            SaveCommand = commandFactory.CreateCommand(Save, () => true);
            CancelCommand = commandFactory.CreateCommand(Cancel, () => true);
        }

        private async void Cancel()
        {
            await navigationService.PopAsync();
        }

        private async void Save()
        {
            await todoClient.TodoInsertOrUpdateItemAsync(TodoItem);
            await navigationService.PopAsync();
        }

        public override async Task OnAppearing()
        {
            await base.OnAppearing();

            if (viewModelParameter != null)
            {
                TodoItem = await todoClient.TodoGetItemAsync(viewModelParameter.Value);
            }
            else
            {
                TodoItem = new TodoItemDto
                {
                    Title = string.Empty,
                    IsCompleted = false
                };
            }
        }
    }
}