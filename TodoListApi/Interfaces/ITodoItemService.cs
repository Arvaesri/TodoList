using TodoListApi.Models;

namespace TodoListApi.Interfaces
{
    public interface ITodoItemService
    {
        Task<TodoItem> CreateTodoItemAsync(string title, string description, DateTime? dueDate);
        Task<TodoItem> GetTodoItemByIdAsync(Guid id);
        Task <TodoItem>UpdateTodoItemAsync(Guid id, string title, string description, bool completed, DateTime? dueDate);
        Task <bool>DeleteTodoItemAsync(Guid id);
    }
}
