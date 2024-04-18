using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoListApi.Models;

namespace TodoListApi.Services
{
    public interface ITodoItemService
    {
        Task<TodoItem> CreateTodoItemAsync(string title, string description, DateTime? dueDate);
        Task<IEnumerable<TodoItem>> GetAllTodoItemsAsync();
        Task<TodoItem> GetTodoItemByIdAsync(Guid id);
        Task UpdateTodoItemAsync(Guid id, string title, string description, bool completed, DateTime updated, DateTime? dueDate);
        Task DeleteTodoItemAsync(Guid id);
    }
}
