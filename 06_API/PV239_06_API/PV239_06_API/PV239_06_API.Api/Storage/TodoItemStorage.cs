using System;
using System.Collections.Generic;
using System.Linq;
using PV239_06_API.Api.Dtos;

namespace PV239_06_API.Api.Storage
{
    public static class TodoItemStorage
    {
        private static List<TodoItemDto> TodoItems { get; set; } = new List<TodoItemDto>
        {
            new TodoItemDto
            {
                Id = Guid.NewGuid(),
                IsCompleted = false,
                Title = "Koupit čokoládu"
            }
        };

        public static List<TodoItemDto> GetAllItems()
        {
            return TodoItems;
        }

        public static TodoItemDto GetItem(Guid id)
        {
            return TodoItems.FirstOrDefault(todoItem => todoItem.Id == id);
        }

        public static void InsertOrUpdateItem(TodoItemDto todoItem)
        {
            if (!TodoItems.Any(todoItemInStorage => todoItemInStorage.Id == todoItem.Id))
            {
                Insert(todoItem);
            }
            else
            {
                Update(todoItem);
            }
        }

        private static void Insert(TodoItemDto todoItem)
        {
            todoItem.Id = Guid.NewGuid();
            TodoItems.Add(todoItem);
        }

        private static void Update(TodoItemDto todoItem)
        {
            var existingTodoItem = TodoItems.First(todoItemInStorage => todoItemInStorage.Id == todoItem.Id);
            var existingTodoItemIndex = TodoItems.IndexOf(existingTodoItem);

            TodoItems.RemoveAt(existingTodoItemIndex);
            TodoItems.Insert(existingTodoItemIndex, todoItem);
        }

        public static void RemoveItem(Guid id)
        {
            var itemToRemove = TodoItems.FirstOrDefault(item => item.Id == id);
            if (itemToRemove != null)
            {
                TodoItems.Remove(itemToRemove);
            }
        }
    }
}