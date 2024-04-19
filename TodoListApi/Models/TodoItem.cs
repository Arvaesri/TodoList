using System.Globalization;

namespace TodoListApi.Models
{
    public class TodoItem
    {
        public Guid Id {  get; private set; } = Guid.NewGuid();
        public string Title { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public bool Completed { get; private set; } = false;
        public readonly DateTime created = DateTime.Now;
        public DateTime Updated { get; private set; } = DateTime.Now;
        public DateTime? dueDate { get; private set; } = null;
    }
}
