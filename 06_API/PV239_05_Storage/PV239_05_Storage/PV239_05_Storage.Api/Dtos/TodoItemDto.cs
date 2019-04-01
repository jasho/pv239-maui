using System;
using PV239_05_Storage.Api.Enums;

namespace PV239_05_Storage.Api.Dtos
{
    public class TodoItemDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
        public TodoItemType Type { get; set; }
    }
}