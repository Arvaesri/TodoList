using Microsoft.AspNetCore.Mvc;
using TodoListApi.Interfaces;
using TodoListApi.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace TodoListApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoItemService _todoItemService;

        public TodoController(ITodoItemService todoService)
        {
            _todoItemService = todoService;
        }

         [HttpPost]
         [SwaggerOperation(Description = "Submit a todo item.")]
        public async Task<IActionResult> CreateTodoItem([FromBody] TodoItem request)
        {
            var todoItem = await _todoItemService.CreateTodoItemAsync(request.Title, request.Description, request.DueDate);
            return Ok(todoItem);
        }

        [HttpGet("{Todoid:guid:required}")]
        [SwaggerOperation(Description = "Retrieve a todo item identified by its id.")]
        public async Task<IActionResult> GetTodoItemById(Guid Todoid)
        {
            var todoItem = await _todoItemService.GetTodoItemByIdAsync(Todoid);
            return Ok(todoItem);
        }

        [HttpPut("{Todoid:guid:required}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Description = "Updates a todo item with the corresponding id.")]
        public async Task<IActionResult> UpdateTodoItem([FromRoute] Guid Todoid, [FromBody] TodoItem request)
        {
            await _todoItemService.UpdateTodoItemAsync(Todoid, request.Title, request.Description, request.Completed, request.DueDate);
            return NoContent();
        }

        [HttpDelete("{Todoid:guid:required}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Description = "Delete a todo item with the corresponding id.")]
        public async Task<IActionResult> DeleteTodoItem(Guid Todoid)
        {
            await _todoItemService.DeleteTodoItemAsync(Todoid);
            return NoContent();
        }
    }
}