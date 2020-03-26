using PV239_06_API.Core.Api;
using PV239_06_API.Core.Factories.Interfaces;
using PV239_06_API.Core.Services.Interfaces;
using PV239_06_API.Core.ViewModels.Base;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PV239_06_API.Core.ViewModels
{
    public class TodoListViewModel : ViewModelBase
    {
        private ICommandFactory commandFactory;
        private readonly INavigationService navigationService;
        private readonly ITodoClient todoClient;

        public ICommand AddItemCommand { get; set; }
        public ICommand NavigateToSettingsCommand { get; set; }

        public ObservableCollection<TodoItemDto> TodoItems { get; set; } = new ObservableCollection<TodoItemDto>();

        public ICommand NavigateToDetailCommand { get; set; }
        public ICommand RemoveCommand { get; set; }

        public TodoListViewModel(
            ICommandFactory commandFactory,
            INavigationService navigationService,
            ITodoClient todoClient)
        {
            this.commandFactory = commandFactory;
            this.navigationService = navigationService;
            this.todoClient = todoClient;

            AddItemCommand = commandFactory.CreateCommand(AddNewItem);
            NavigateToSettingsCommand = commandFactory.CreateCommand(NavigateToSettings);
            NavigateToDetailCommand = commandFactory.CreateCommand<Guid>(NavigateToDetail);
            RemoveCommand = commandFactory.CreateCommand<Guid>(Remove);
        }

        private async void Remove(Guid id)
        {
            await todoClient.TodoRemoveItemAsync(id);
            await OnAppearing();
        }

        private async void NavigateToDetail(Guid id)
        {
            await navigationService.PushAsync<TodoDetailViewModel, Guid?>(id);
        }

        public override async Task OnAppearing()
        {
            await base.OnAppearing();

            try
            {
                TodoItems.Clear();
                var todoItems = await todoClient.TodoGetAllItemsAsync();
                foreach (var todoItem in todoItems)
                {
                    TodoItems.Add(todoItem);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private async void NavigateToSettings()
        {
            await navigationService.PushAsync<SettingsViewModel>();
        }

        private async void AddNewItem()
        {
            await navigationService.PushAsync<TodoDetailViewModel, Guid?>(null);
        }
    }
}