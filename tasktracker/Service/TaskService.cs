using System.Text.Json;

namespace tasktracker
{
    public class TaskService(IEnumerable<WorkItem> tasks) : ITaskService
    {
        public int GetLastestWorkItemId() => tasks.LastOrDefault()?.Id ?? 0;
        public void SaveWorkItem(WorkItem workItem)
        {
            string jsonDocument = JsonSerializer.Serialize(tasks);
            var newTasks = tasks.Append(workItem);
            File.WriteAllText("work-items.json", JsonSerializer.Serialize(newTasks));
        }
        public WorkItem AddTask(string workItemName)
        {
            var workItem = new WorkItem { Id = GetLastestWorkItemId() + 1, Description = workItemName };
            SaveWorkItem(workItem);
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
                Console.WriteLine($"{task.Id} - {task.Description} - {task.Status} - {task.CreatedAt} - {task.UpdatedAt}");
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