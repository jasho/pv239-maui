using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
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

        public ICommand AddItemCommand { get; set; }
        public ICommand DeleteItemCommand { get; set; }
        public ICommand NavigateToSettingsCommand { get; set; }

        public ObservableCollection<TodoItemModel> TodoItems { get; set; } = new ObservableCollection<TodoItemModel>();

        public TodoListViewModel(
            ICommandFactory commandFactory,
            IPreferencesService preferencesService,
            INavigationService navigationService,
            IDatabaseService databaseService)
        {
            this.commandFactory = commandFactory;
            this.preferencesService = preferencesService;
            this.navigationService = navigationService;
            this.databaseService = databaseService;

            AddItemCommand = commandFactory.CreateCommand(AddNewItem);
            DeleteItemCommand = commandFactory.CreateCommand<TodoItemModel>(DeleteItem);
            NavigateToSettingsCommand = commandFactory.CreateCommand(NavigateToSettings);
        }

        private async void NavigateToSettings()
        {
            await navigationService.PushAsync<SettingsViewModel>();
        }

        public override async Task OnAppearing()
        {
            await base.OnAppearing();
            TodoItems = preferencesService.Get<ObservableCollection<TodoItemModel>>("TodoItems");

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
            //foreach (var todoItem in TodoItems)
            //{
            //    databaseService.Set(todoItem);
            //}
        }
    }
}