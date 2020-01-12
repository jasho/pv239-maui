using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using PV239_06_API.Core.Api;
using PV239_06_API.Core.Factories.Interfaces;
using PV239_06_API.Core.Models;
using PV239_06_API.Core.Services.Interfaces;
using PV239_06_API.Core.ViewModels.Base;

namespace PV239_06_API.Core.ViewModels
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
            NavigateToDetailCommand = commandFactory.CreateCommand<Guid>(NavigateToDetail);
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
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
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

        //private async void NavigateToDetail(TodoItemModel todoItem)
        //{
        //    var itemFromApi = await apiClient.TodoGetItemAsync(todoItem.Id);
        //    await navigationService.PushAsync<TodoDetailViewModel, Guid?>(todoItem.Id);
        //}

        private async void NavigateToSettings()
        {
            await navigationService.PushAsync<SettingsViewModel>();
        }


        private void DeleteItem(TodoItemModel todoItem)
        {
            TodoItems.Remove(todoItem);
        }

        private async void AddNewItem()
        {
            await navigationService.PushAsync<TodoDetailViewModel, Guid?>(null);
            //TodoItems.Add(new TodoItemModel { Title = "Nový úkol", IsCompleted = false });
            //preferencesService.Set("TodoItems", TodoItems);
            //foreach (var todoItem in TodoItems)
            //{
            //    databaseService.Set(todoItem);
            //}
        }
    }
}