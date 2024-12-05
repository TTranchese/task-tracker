namespace tasktracker
{
    public class WorkItem
    {
        public int Id { get; set; }
        public required string Description { get; set; }
        public StatusEnum Status { get; set; } = StatusEnum.ToDo;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set;} = DateTime.Now;
    }

    public enum StatusEnum
    {
        Done,
        InProgress,
        ToDo
    }
}