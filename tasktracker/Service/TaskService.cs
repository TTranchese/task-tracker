using System.Text.Json;

namespace tasktracker
{
    public class TaskService(IEnumerable<WorkItem> tasks) : ITaskService
    {
        private int GetLastestWorkItemId() => tasks.LastOrDefault()?.Id ?? 0;
        private void SaveWorkItem(WorkItem workItem)
        {
            string jsonDocument = JsonSerializer.Serialize(tasks);
            var newTasks = tasks.Append(workItem);
            File.WriteAllText("work-items.json", JsonSerializer.Serialize(newTasks));
        }
        private void SaveWorkItems(IEnumerable<WorkItem> workItems)
        {
            foreach (var workItem in workItems)
            {
                SaveWorkItem(workItem);
            }
        }

        private WorkItem? FindWorkItem(int id)
        {
            return tasks.Where(task => task.Id == id).FirstOrDefault();
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

        public WorkItem? RemoveTask(int id)
        {
            var taskToRemove = FindWorkItem(id);
            var removedTaskList = tasks.Where(task => task.Id != id);
            SaveWorkItems(removedTaskList);
            return taskToRemove;
        }

        public WorkItem ChangeStatusTask(int id, StatusEnum statusEnum)
        {
            throw new NotImplementedException();
        }
    }
}