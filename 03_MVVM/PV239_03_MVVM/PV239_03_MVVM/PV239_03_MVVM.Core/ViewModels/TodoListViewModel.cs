using PV239_03_MVVM.Core.Factories.Interfaces;
using PV239_03_MVVM.Core.Models;
using PV239_03_MVVM.Core.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PV239_03_MVVM.Core.ViewModels
{
    public class TodoListViewModel : ViewModelBase
    {
        private ICommandFactory commandFactory;

        public ICommand AddItemCommand { get; set; }
        public ICommand DeleteItemCommand { get; set; }

        public ObservableCollection<TodoItemModel> TodoItems { get; set; } = new ObservableCollection<TodoItemModel>
        {
            new TodoItemModel{ Title = "Přijít na cvičení", IsCompleted = true},
            new TodoItemModel{ Title = "Dokončit cvičení", IsCompleted = false},
            new TodoItemModel{ Title = "Koupit čokoládu", IsCompleted = false}
        };

        public TodoListViewModel(ICommandFactory commandFactory)
        {
            this.commandFactory = commandFactory;
            AddItemCommand = commandFactory.CreateCommand(AddNewItem);
            DeleteItemCommand = commandFactory.CreateCommand<TodoItemModel>(DeleteItem);
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