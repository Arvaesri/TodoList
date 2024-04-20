using TodoListApi.Db;
using TodoListApi.Interfaces;
using TodoListApi.Models;
using System.Net;

namespace TodoListApi.Services
{
    public class TodoItemService : ITodoItemService
    {
        private readonly TodoItemContext _context;

        public TodoItemService(TodoItemContext context)
        {
            _context = context;
        }

        public async Task<TodoItem> CreateTodoItemAsync(string title, string description, DateTime? dueDate)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Title cannot be empty or null.");
            }

            var newTodo = new TodoItem
            {
                Title = title,
                Description = description,
                DueDate = dueDate,
                Deleted = false
            };

            await _context.AddAsync(newTodo);
            await _context.SaveChangesAsync();
            return newTodo;
        }

        public async Task<TodoItem> GetTodoItemByIdAsync(Guid id)
        {
            var todo = await _context.FindAsync<TodoItem>(id) ?? throw new HttpStatusCodeException(HttpStatusCode.NotFound, "Todo item with the specified ID does not exist.");
            return todo;
        }

        public async Task<TodoItem> UpdateTodoItemAsync(Guid id, string title, string description, bool completed, DateTime? dueDate)
        {
            var existingTodo = await _context.FindAsync<TodoItem>(id) ?? throw new HttpStatusCodeException(HttpStatusCode.NotFound, "Todo item with the specified ID does not exist.");

            existingTodo.Title = title;
            existingTodo.Description = description;
            existingTodo.Completed = completed;
            existingTodo.Updated = DateTime.Now;
            existingTodo.DueDate = dueDate;
            await _context.SaveChangesAsync();
            return existingTodo;
        }

        public async Task<bool> DeleteTodoItemAsync(Guid id)
        {
            var existingTodo = await _context.FindAsync<TodoItem>(id) ?? throw new HttpStatusCodeException(HttpStatusCode.NotFound, "Todo item with the specified ID does not exist.");
            existingTodo.Deleted = true;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}