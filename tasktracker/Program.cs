using System.Text.Json;
using tasktracker;
if (!File.Exists("tasks.json"))
{
    File.WriteAllText("tasks.json", "[]");
}
var tasks = JsonSerializer.Deserialize<IEnumerable<WorkItem>>(File.ReadAllText("tasks.json"));
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
        _taskService.CompleteTask(args[1]);
        break;
    case "--help":
    case "-h":
    default:
        Console.WriteLine("Help");
        break;
}