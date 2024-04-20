using Microsoft.EntityFrameworkCore;
using TodoListApi.Models;

namespace TodoListApi.Db;

public class TodoItemContext : DbContext
{
    public TodoItemContext (DbContextOptions<TodoItemContext> options) : base(options) {}    
    public DbSet<TodoItem> Todoitems {get; set;}
}
