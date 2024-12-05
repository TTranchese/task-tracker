using System.Text.Json;
using tasktracker;
var filePath = "work-items.json";
if (!File.Exists(filePath))
{
    File.WriteAllText(filePath, "[]");
}
var tasks = JsonSerializer.Deserialize<IEnumerable<WorkItem>>(File.ReadAllText("work-items.json"));
var _taskService = new TaskService(tasks, filePath);

switch(args[0]) {
    case "--list":
    case "-l":
        _taskService.ListAllTasks();
        Console.WriteLine("Tasks listed successfully.");
        break;
    case "--add":
    case "-a":
        _taskService.AddTask(args[1]);
        Console.WriteLine("Task added successfully.");
        break;
    case "--remove":
    case "-r":
        _taskService.RemoveTask(args[1]);
        Console.WriteLine("Task removed successfully.");
        break;
    case "--complete":
    case "-c":
        _taskService.ChangeStatusTask(args[1], args[2]);
        Console.WriteLine("Task status changed successfully.");
        break;
    case "--help":
    case "-h":
    default:
        Console.WriteLine("Usage:");
        Console.WriteLine("  dotnet run --project tasktracker [command] [options]");
        Console.WriteLine();
        Console.WriteLine("Commands:");
        Console.WriteLine("  -a|--add \"New Task\"        Add a new task");
        Console.WriteLine("  -l|--list                   List all tasks");
        Console.WriteLine("  -r|--remove 1               Remove a task by ID");
        Console.WriteLine("  -c|--change 1 [ToDo|Pending|Complete]  Change status of a task by ID");
        Console.WriteLine("  -h|--help                   Print command list");
        break;
}