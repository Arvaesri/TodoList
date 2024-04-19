using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoListApi.Interfaces;
using TodoListApi.Models;

namespace TodoListApi.Services
{
    public class ToDoItemService : ITodoItemService
    {
        private readonly IToDoRepository _repository; // Dependency for data access

        public ToDoItemService(IToDoRepository repository)
        {
            _repository = repository;
        }

        public async Task<TodoItem> CreateTodoItemAsync(string title, string description, DateTime? dueDate)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentException("Title cannot be empty or null.");
            }

            var newTodo = new TodoItem
            {
                Title = title,
                Description = description,
                DueDate = dueDate
            };

            await _repository.AddAsync(newTodo);
            return newTodo;
        }

        public async Task<IEnumerable<TodoItem>> GetAllTodoItemsAsync()
        {
            var allTodos = await _repository.GetAllAsync();
            return allTodos;
        }

        public async Task<TodoItem> GetTodoItemByIdAsync(Guid id)
        {
            var todo = await _repository.GetByIdAsync(id);
            return todo;
        }

        public async Task UpdateTodoItemAsync(Guid id, string title, string description, bool completed, DateTime updated, DateTime? dueDate)
        {
            var existingTodo = await _repository.GetByIdAsync(id);

            if (existingTodo == null)
            {
                throw new ArgumentException("Todo item with the specified ID does not exist.");
            }

            existingTodo.Title = title;
            existingTodo.Description = description;
            existingTodo.Completed = completed;
            existingTodo.Updated = updated;
            existingTodo.DueDate = dueDate;

            await _repository.UpdateAsync(existingTodo);
        }

        public async Task DeleteTodoItemAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}