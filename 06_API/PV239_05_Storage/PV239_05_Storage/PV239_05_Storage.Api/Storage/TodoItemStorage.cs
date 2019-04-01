using System;
using System.Collections.Generic;
using PV239_05_Storage.Api.Dtos;

namespace PV239_05_Storage.Api.Storage
{
    public static class TodoItemStorage
    {
        public static List<TodoItemDto> TodoItems { get; set; } = new List<TodoItemDto>
        {
            new TodoItemDto
            {
                Id = Guid.NewGuid(),
                IsCompleted = false,
                Title = "Koupit čokoládu"
            }
        };
    }
}