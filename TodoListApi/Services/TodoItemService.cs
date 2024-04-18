using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoListApi.Interfaces;

namespace TodoListApi.Services
{
    public class TodoItemService : ITodoItemService
    {
        public async Task<TodoItem> CreateTodoItemAsync(string title, string description, DateTime? dueDate)
        {
            var todoItem = new TodoItem(title, description, dueDate);
            // You might add data access logic here to save the todoItem to a database
            return await Task.FromResult(todoItem);
        }

        public async Task<IEnumerable<TodoItem>> GetAllTodoItemsAsync()
        {
            // You might add data access logic here to retrieve all todoItems from a database
            return await Task.FromResult(new List<TodoItem>());
        }

        public async Task<TodoItem> GetTodoItemByIdAsync(Guid id)
        {
            // You might add data access logic here to retrieve a todoItem by its id from a database
            return await Task.FromResult<TodoItem>(null);
        }

        public async Task UpdateTodoItemAsync(Guid id, string title, string description, bool completed, DateTime updated, DateTime? dueDate)
        {
            // You might add data access logic here to update a todoItem in a database
            await Task.CompletedTask;
        }

        public async Task DeleteTodoItemAsync(Guid id)
        {
            // You might add data access logic here to delete a todoItem from a database
            await Task.CompletedTask;
        }
    }
}