using System.ComponentModel;
using System.Text.Json;

namespace tasktracker
{
    public class TaskService(IEnumerable<WorkItem> tasks, string filePath) : ITaskService
    {
        public int GetLastestWorkItemId() => tasks.AsQueryable().OrderBy(x => x.Id).LastOrDefault()?.Id ?? 0;
        public void SaveWorkItem(WorkItem workItem)
        {
            var newTasks = tasks.Append(workItem);
            File.WriteAllText(filePath, JsonSerializer.Serialize(newTasks));
        }

        public void SaveWorkItems(IEnumerable<WorkItem> workItems)
        {
            foreach (var workItem in workItems)
            {
                SaveWorkItem(workItem);
            }
        }

        public WorkItem? FindWorkItem(int id)
        {
            return tasks.Where(task => task.Id == id).FirstOrDefault() ?? null;
        }
        public WorkItem AddTask(string workItemName)
        {
            var workItem = new WorkItem { Id = GetLastestWorkItemId() + 1, Description = workItemName };
            SaveWorkItem(workItem);
            return workItem;
        }


        public IEnumerable<WorkItem> ListAllTasks()
        {
            Console.WriteLine("All Tasks:");
            foreach (var task in tasks)
            {
                Console.WriteLine($"{task.Id} - {task.Description} - {task.Status} - {task.CreatedAt} - {task.UpdatedAt}");
            }
            return tasks;
        }

        public WorkItem? RemoveTask(string id)
        {
            var taskToRemove = FindWorkItem(Int32.Parse(id));
            var removedTaskList = tasks.Where(task => task.Id != taskToRemove.Id).ToList();
            SaveWorkItems(removedTaskList);
            return taskToRemove;
        }

        public WorkItem ChangeStatusTask(string id, string status)
        {
            var task = FindWorkItem(int.Parse(id));
            if (task == null)
            {
                Console.Out.WriteLine("Task not found");
                return new WorkItem(){Description = "Empty"};
            }
            task.Status = Enum.Parse<StatusEnum>(status);
            SaveWorkItem(task);
            return task;
        }
    }
}