namespace tasktracker
{
    public interface ITaskService
    {
        public int GetLastestWorkItemId();
        public void SaveWorkItem(WorkItem workItem);

        public void SaveWorkItems(IEnumerable<WorkItem> workItems);

        public WorkItem? FindWorkItem(int id);
        public WorkItem AddTask(string workItemName);


        public IEnumerable<WorkItem> ListAllTasks();

        public WorkItem? RemoveTask(string id);

        public WorkItem ChangeStatusTask(string id, string status);
    }
}