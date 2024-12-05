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
        break;
    case "--add":
    case "-a":
        _taskService.AddTask(args[1]);
        break;
    case "--remove":
    case "-r":
        _taskService.RemoveTask(args[1]);
        break;
    case "--complete":
    case "-c":
        _taskService.ChangeStatusTask(args[1], args[2]);
        break;
    case "--help":
    case "-h":
    default:
        Console.WriteLine("Help");
        break;
}