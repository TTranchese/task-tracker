namespace tasktracker
{
    public interface ITaskService
    {
        public WorkItem AddTask(string workItemDesc);

        public WorkItem ChangeStatusTask(int id, StatusEnum statusEnum);

        public IEnumerable<WorkItem> ListAllTasks();

        public WorkItem? RemoveTask(int id);

    }
}