using System.Globalization;

namespace TodoListApi.Models
{
    internal class TodoItem
    {
        public Guid Id {  get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public bool Completed { get; private set; }
        public readonly DateTime created; 
        public DateTime Updated { get; private set; }
        public DateTime? dueDate;
        public TodoItem(string title, string description, DateTime? dueDate)
        {
            this.Id = Guid.NewGuid();
            this.Title = title;
            this.Description = description;
            this.Completed = false;
            this.created = DateTime.Now;
            this.dueDate = dueDate;
        }
    }
}
