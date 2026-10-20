using System.Text.Json;
using TaskTracker.Models;

namespace TaskTracker.Services
{
    public class FileService
    {
        private readonly string _filePath = "tasks.json";
        public List<TaskItem> LoadTasks()
        {
            if (!File.Exists(_filePath))
                return new List<TaskItem>();

            string json = File.ReadAllText(_filePath);

            if (string.IsNullOrEmpty(json))
                return new List<TaskItem>();

            return JsonSerializer.Deserialize<List<TaskItem>>(json) ?? new List<TaskItem>();
        }
        public void SaveTasks(List<TaskItem> tasks)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(tasks, options);

            File.WriteAllText(_filePath, json);
        }
    }
}