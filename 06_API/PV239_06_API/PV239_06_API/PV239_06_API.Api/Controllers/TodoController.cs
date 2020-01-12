using Microsoft.AspNetCore.Mvc;
using PV239_06_API.Api.Dtos;
using PV239_06_API.Api.Storage;
using System;
using System.Collections.Generic;

namespace PV239_06_API.Api.Controllers
{
    [Route("/api/todo")]
    public class TodoController : Controller
    {
        [HttpGet("items", Name = "TodoGetAllItems")]
        public ActionResult<List<TodoItemDto>> GetAllItems()
        {
            return TodoItemStorage.GetAllItems();
        }

        [HttpGet("item/{id}", Name = "TodoGetItem")]
        public ActionResult<TodoItemDto> GetItem(Guid id)
        {
            return TodoItemStorage.GetItem(id);
        }

        [HttpPost("item", Name = "TodoInsertOrUpdateItem")]
        public ActionResult InsertOrUpdateItem([FromBody]TodoItemDto todoItem)
        {
            TodoItemStorage.InsertOrUpdateItem(todoItem);
            return Ok();
        }
    }
}
