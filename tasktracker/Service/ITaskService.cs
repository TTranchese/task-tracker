namespace tasktracker
{
    public interface ITaskService
    {
        public WorkItem AddTask(string workItemName);

        public WorkItem CompleteTask(string id);

        public IEnumerable<WorkItem> ListAllTasks();

        public void RemoveTask(string id);
        public WorkItem GetWorkItem(string id);
    }
}