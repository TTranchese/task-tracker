using System.Text.Json;

namespace tasktracker
{
    public class TaskService(IEnumerable<WorkItem> tasks) : ITaskService
    {
        public int GetLastestWorkItemId() => tasks.Last()?.Id ?? 1;
        public void SaveTasks() => File.WriteAllText("tasks.json", JsonSerializer.Serialize(tasks));
        public WorkItem AddTask(string workItemName)
        {
            var workItem = new WorkItem { Id = GetLastestWorkItemId() + 1, Name = workItemName };
            _ = tasks.Append(workItem);
            SaveTasks();
            return workItem;
        }

        public WorkItem CompleteTask(string id)
        {
            throw new NotImplementedException();
        }

        public WorkItem GetWorkItem(string id)
        {
            throw new NotImplementedException();
        }

        public void ListAllTasks()
        {
            Console.Clear();
            Console.WriteLine("All Tasks:");
            foreach (var task in tasks)
            {
                Console.WriteLine($"{task.Id} - {task.Name} - {task.IsComplete}");
            }
        }

        public void RemoveTask(string id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<WorkItem> ITaskService.ListAllTasks()
        {
            throw new NotImplementedException();
        }
    }
}