using Microsoft.EntityFrameworkCore;
using TodoListApi.Models;

namespace TodoListApi.Db;

public class TodoItemContext : DbContext
{
    public DbSet<TodoItem> Todoitems {get; set;}
    public TodoItemContext (DbContext.Options<TodoItemContext> options) : base(options){

    }
}
