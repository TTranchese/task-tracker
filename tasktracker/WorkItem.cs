namespace tasktracker
{
    public class WorkItem
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public bool IsComplete { get; set; } = false;
    }
}