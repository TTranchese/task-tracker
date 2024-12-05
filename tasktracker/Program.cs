using System.Text.Json;
using tasktracker;
if (!File.Exists("work-items.json"))
{
    File.WriteAllText("work-items.json", "[]");
}
var tasks = JsonSerializer.Deserialize<IEnumerable<WorkItem>>(File.ReadAllText("work-items.json"));
var _taskService = new TaskService(tasks);

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
        _taskService.ChangeStatusTask(args[1]);
        break;
    case "--help":
    case "-h":
    default:
        Console.WriteLine("Help");
        break;
}