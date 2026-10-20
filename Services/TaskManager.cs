using TaskTracker.Models;

namespace TaskTracker.Services
{
    public class TaskManager
    {
        private readonly FileService _fileService;
        private readonly List<TaskItem> _tasks;

        public TaskManager()
        {
            _fileService = new FileService();
            _tasks = _fileService.LoadTasks();
        }
        public void AddTask(string Discreption)
        {
            int nextId = (_tasks.Count > 0) ? _tasks.Max(t => t.Id) + 1 : 1;

            TaskItem newTask = new TaskItem()
            {
                Id = nextId,
                Discription = Discreption,
                Status = "todo",
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            };

            _tasks.Add(newTask);
            _fileService.SaveTasks(_tasks);
            Console.WriteLine($"Task added successfully ID: {nextId}");
        }
        public void UpdateTask(int Id, string newDiscrption)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == Id);

            if (task == null)
            {
                Console.WriteLine($"Error: Task with ID {Id} not found.");
                return;
            }

            task.Discription = newDiscrption;
            task.UpdatedDate = DateTime.UtcNow;
            _fileService.SaveTasks(_tasks);
            Console.WriteLine($"Task {Id} updated successfully.");
        }
        public void DeleteTask(int Id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == Id);

            if (task == null)
            {
                Console.WriteLine($"Error: Task with ID {Id} not found.");
                return;
            }

            _tasks.Remove(task);
            _fileService.SaveTasks(_tasks);
            Console.WriteLine($"Task {Id} deleted successfully.");
        }
        public void MarkStatus(int Id, string newStatus)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == Id);

            if (task == null)
            {
                Console.WriteLine($"Error: Task with ID {Id} not found.");
                return;
            }

            task.Status = newStatus;
            task.UpdatedDate = DateTime.UtcNow;
            _fileService.SaveTasks(_tasks);
            Console.WriteLine($"Task {Id} marked as {newStatus}.");
        }
        public void ListTasks(string? statusFilter = null)
        {
            var query = _tasks.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(statusFilter))
            {
                query = _tasks.Where(t => t.Status.Equals(statusFilter, StringComparison.OrdinalIgnoreCase));
            }

            var tasksList = query.ToList();

            if (!tasksList.Any())
            {
                Console.WriteLine("No tasks found.");
                return;
            }

            foreach (var task in tasksList)
            {
                Console.WriteLine($"[{task.Id}] {task.Discription} - Status: {task.Status} (Created: {task.CreatedDate:yyyy-MM-dd HH:mm})");
            }
        }
    }
}