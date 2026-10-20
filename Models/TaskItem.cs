
namespace TaskTracker.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Discription { get; set; } = string.Empty;
        public string Status { get; set; } = "todo";
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
    }
}
