namespace PV239_06_API.Core.Models
{
    public class TodoItemModel : ModelBase
    {
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
    }
}