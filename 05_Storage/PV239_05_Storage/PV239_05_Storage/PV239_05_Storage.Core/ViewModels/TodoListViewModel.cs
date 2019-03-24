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

        public ICommand AddItemCommand { get; set; }
        public ICommand DeleteItemCommand { get; set; }

        public ObservableCollection<TodoItemModel> TodoItems { get; set; } = new ObservableCollection<TodoItemModel>();

        public TodoListViewModel(
            ICommandFactory commandFactory,
            IPreferencesService preferencesService)
        {
            this.commandFactory = commandFactory;
            this.preferencesService = preferencesService;
            AddItemCommand = commandFactory.CreateCommand(AddNewItem);
            DeleteItemCommand = commandFactory.CreateCommand<TodoItemModel>(DeleteItem);
        }

        public override async Task OnAppearing()
        {
            await base.OnAppearing();

            TodoItems = preferencesService.Get<ObservableCollection<TodoItemModel>>("TodoItems");
        }

        private void DeleteItem(TodoItemModel todoItem)
        {
            TodoItems.Remove(todoItem);
        }

        private void AddNewItem()
        {
            TodoItems.Add(new TodoItemModel { Title = "Nový úkol", IsCompleted = false });
        }
    }
}