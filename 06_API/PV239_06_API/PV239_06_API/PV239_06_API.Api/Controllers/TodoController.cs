using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using PV239_06_API.Api.Dtos;
using PV239_06_API.Api.Storage;
using System;
using System.Collections.Generic;

namespace PV239_06_API.Api.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class TodoController : ControllerBase
    {
        private const string ApiOperationBaseName = "Todo";

        [HttpGet]
        [OpenApiOperation(ApiOperationBaseName + nameof(GetAllItems))]
        public ActionResult<List<TodoItemDto>> GetAllItems()
        {
            return TodoItemStorage.GetAllItems();
        }

        [HttpGet]
        [Route("{id}")]
        [OpenApiOperation(ApiOperationBaseName + nameof(GetItem))]
        public ActionResult<TodoItemDto> GetItem(Guid id)
        {
            return TodoItemStorage.GetItem(id);
        }

        [HttpPost]
        [OpenApiOperation(ApiOperationBaseName + nameof(InsertOrUpdateItem))]
        public ActionResult InsertOrUpdateItem([FromBody]TodoItemDto todoItem)
        {
            TodoItemStorage.InsertOrUpdateItem(todoItem);
            return Ok();
        }

        [HttpDelete("{id}")]
        [OpenApiOperation(ApiOperationBaseName + nameof(RemoveItem))]
        public ActionResult RemoveItem(Guid id)
        {
            TodoItemStorage.RemoveItem(id);
            return Ok();
        }
    }
}
