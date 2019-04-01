using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PV239_05_Storage.Api.Dtos;
using PV239_05_Storage.Api.Storage;
using Swashbuckle.AspNetCore.Annotations;

namespace PV239_05_Storage.Api.Controllers
{
    [Route("/api/todo")]
    public class TodoController : Controller
    {
        [HttpGet]
        [Route("items")]
        [SwaggerOperation(OperationId = "TodoGetAllItems")]
        public ActionResult<List<TodoItemDto>> GetAllItems()
        {
            return TodoItemStorage.TodoItems;
        }

        [HttpGet]
        [Route("item/{id}")]
        [SwaggerOperation(OperationId = "TodoGetItem")]
        public ActionResult<TodoItemDto> GetItem(Guid id)
        {
            return TodoItemStorage.TodoItems.FirstOrDefault(item => item.Id == id);
        }

        [HttpPost]
        [Route("item")]
        [SwaggerOperation(OperationId = "TodoInsertItem")]
        public ActionResult InsertItem(TodoItemDto todoItem)
        {
            TodoItemStorage.TodoItems.Add(todoItem);
            return Ok();
        }
    }
}
