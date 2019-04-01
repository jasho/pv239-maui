using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using PV239_05_Storage.Core.Api;
using PV239_05_Storage.Core.Factories.Interfaces;
using PV239_05_Storage.Core.Models;
using PV239_05_Storage.Core.Services.Interfaces;
using PV239_05_Storage.Core.ViewModels.Base;

namespace PV239_05_Storage.Core.ViewModels
{
    public class TodoListViewModel : ViewModelBase
    {
        private ICommandFactory commandFactory;
        private readonly IPreferencesService preferencesService;
        private readonly INavigationService navigationService;
        private readonly IDatabaseService databaseService;
        private readonly IApiClient apiClient;

        public ICommand AddItemCommand { get; set; }
        public ICommand DeleteItemCommand { get; set; }
        public ICommand NavigateToSettingsCommand { get; set; }

        public ObservableCollection<TodoItemModel> TodoItems { get; set; } = new ObservableCollection<TodoItemModel>();

        public ICommand NavigateToDetailCommand { get; set; }

        public TodoListViewModel(
            ICommandFactory commandFactory,
            IPreferencesService preferencesService,
            INavigationService navigationService,
            IDatabaseService databaseService,
            IApiClient apiClient)
        {
            this.commandFactory = commandFactory;
            this.preferencesService = preferencesService;
            this.navigationService = navigationService;
            this.databaseService = databaseService;
            this.apiClient = apiClient;

            AddItemCommand = commandFactory.CreateCommand(AddNewItem);
            DeleteItemCommand = commandFactory.CreateCommand<TodoItemModel>(DeleteItem);
            NavigateToSettingsCommand = commandFactory.CreateCommand(NavigateToSettings);
            NavigateToDetailCommand = commandFactory.CreateCommand<TodoItemModel>(NavigateToDetail);
        }

        private async void NavigateToDetail(TodoItemModel todoItem)
        {
            var itemFromApi = await apiClient.TodoGetItemAsync(todoItem.Id);
            await navigationService.PushAsync<TodoDetailViewModel, Guid>(todoItem.Id);
        }

        private async void NavigateToSettings()
        {
            await navigationService.PushAsync<SettingsViewModel>();
        }

        public override async Task OnAppearing()
        {
            await base.OnAppearing();

            TodoItems.Clear();
            var todoItemDtos = await apiClient.TodoGetAllItemsAsync();
            foreach (var todoItemDto in todoItemDtos)
            {
                TodoItems.Add(new TodoItemModel
                {
                    Id = todoItemDto.Id ?? Guid.Empty,
                    IsCompleted = todoItemDto.IsCompleted ?? false,
                    Title = todoItemDto.Title
                });
            }

            //TodoItems = preferencesService.Get<ObservableCollection<TodoItemModel>>("TodoItems");

            //await databaseService.CreateTable<TodoItemModel>();
            //TodoItems = new ObservableCollection<TodoItemModel>();
            //var todoItemModels = await databaseService.GetAll<TodoItemModel>();

            //foreach (var todoItemModel in todoItemModels)
            //{
            //    TodoItems.Add(todoItemModel);
            //}
        }

        private void DeleteItem(TodoItemModel todoItem)
        {
            TodoItems.Remove(todoItem);
        }

        private void AddNewItem()
        {
            TodoItems.Add(new TodoItemModel { Title = "Nový úkol", IsCompleted = false });
            preferencesService.Set("TodoItems", TodoItems);
            //foreach (var todoItem in TodoItems)
            //{
            //    databaseService.Set(todoItem);
            //}
        }
    }
}