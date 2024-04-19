using Microsoft.AspNetCore.Mvc;

namespace TodoListApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly IToDoService _todoService;

        public TodoController(IToDoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        [Route("api/todos")]
        public async Task<IActionResult> GetTodos()
        {
            var todos = await _todoService.GetAllAsync();
            return Ok(todos);
        }

        [HttpGet]
        [Route("api/todos/{todoId}")]
        public async Task<IActionResult> GetTodosById()
        {
            var todos = await _todoService.Get();
            return Ok(todos);
        }
}
}
