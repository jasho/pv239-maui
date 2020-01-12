using Microsoft.AspNetCore.Mvc;
using PV239_06_API.Api.Dtos;
using PV239_06_API.Api.Storage;
using System;
using System.Collections.Generic;
using Swashbuckle.AspNetCore.Annotations;

namespace PV239_06_API.Api.Controllers
{
    [Route("/api/todo")]
    public class TodoController : Controller
    {
        [HttpGet]
        [Route("items")]
        [SwaggerOperation(OperationId = "TodoGetAllItems")]
        public ActionResult<List<TodoItemDto>> GetAllItems()
        {
            return TodoItemStorage.GetAllItems();
        }

        [HttpGet]
        [Route("item/{id}")]
        [SwaggerOperation(OperationId = "TodoGetItem")]
        public ActionResult<TodoItemDto> GetItem(Guid id)
        {
            return TodoItemStorage.GetItem(id);
        }

        [HttpPost]
        [Route("item")]
        [SwaggerOperation(OperationId = "TodoInsertOrUpdateItem")]
        public ActionResult InsertOrUpdateItem([FromBody]TodoItemDto todoItem)
        {
            TodoItemStorage.InsertOrUpdateItem(todoItem);
            return Ok();
        }
    }
}
