using System.Globalization;

namespace TodoListApi.Models
{
    public class TodoItem
    {
        public Guid Id {  get; private set; } = Guid.NewGuid();
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool Completed { get; set; } = false;
        public readonly DateTime created = DateTime.Now;
        public DateTime Updated { get; set; } = DateTime.Now;
        public DateTime? DueDate { get; set; } = null;
        public bool Deleted { get; set; } = false;
    }
}
