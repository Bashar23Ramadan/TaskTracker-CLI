using TaskTracker.Services;

public class Program
{
    private static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Use: task-cli <command> [arguments]");
            return;
        }

        var manager = new TaskManager();
        string command = args[0].ToLower();

        switch (command)
        {
            case "add":
                if (args.Length < 2) { Console.WriteLine("Error: Description required."); return; }
                manager.AddTask(args[1]);
                break;

            case "update":
                if (args.Length < 3 || !int.TryParse(args[1], out int updateId))
                { Console.WriteLine("Error: Valid ID and new description required."); return; }
                manager.UpdateTask(updateId, args[2]);
                break;

            case "delete":
                if (args.Length < 2 || !int.TryParse(args[1], out int deleteId))
                { Console.WriteLine("Error: Valid ID required."); return; }
                manager.DeleteTask(deleteId);
                break;

            case "mark-in-progress":
                if (args.Length < 2 || !int.TryParse(args[1], out int progressId))
                { Console.WriteLine("Error: Valid ID required."); return; }
                manager.MarkStatus(progressId, "in-progress");
                break;

            case "mark-done":
                if (args.Length < 2 || !int.TryParse(args[1], out int doneId))
                { Console.WriteLine("Error: Valid ID required."); return; }
                manager.MarkStatus(doneId, "done");
                break;

            case "list":
                string? filter = (args.Length > 1) ? args[1] : null;
                manager.ListTasks(filter);
                break;

            case "-help":
                ListCommands();
                break;

            default:
                Console.WriteLine($"Unknown command: {command}");
                Console.WriteLine("use -help command to list all commands");
                break;
        }
    }
    private static void ListCommands()
    {
        Console.WriteLine("# Adding a new task");
        Console.WriteLine("task-cli add \"your task discreption\"\n");

        Console.WriteLine("# Updating and deleting tasks");
        Console.WriteLine("task-cli update 1 \"Buy groceries and cook dinner\"");
        Console.WriteLine("task-cli delete 1\n");

        Console.WriteLine("# Marking a task as in progress or done");
        Console.WriteLine("task-cli mark-in-progress 1");
        Console.WriteLine("task-cli mark-done 1\n");

        Console.WriteLine("# Listing all tasks");
        Console.WriteLine("task-cli list\n");

        Console.WriteLine("# Listing tasks by status");
        Console.WriteLine("task-cli list done");
        Console.WriteLine("task-cli list todo");
        Console.WriteLine("task-cli list in-progress\n");
    }
}