using System.Text.Json;

namespace tasktracker.test
{
    public class TaskServiceTest
    {
        private TaskService _sut;
        private List<WorkItem> _tasks;
        private const string FilePath = "mock/test.json";

        [SetUp]
        public void Setup()
        {
            if (File.Exists(FilePath))
            {
                File.Delete(FilePath);
            }

            _tasks = new List<WorkItem>
            {
                new WorkItem { Id = 1, Description = "Task 1", Status = StatusEnum.InProgress, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new WorkItem { Id = 2, Description = "Task 2", Status = StatusEnum.Done, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }
            };
            Directory.CreateDirectory(Path.GetDirectoryName(FilePath));
            File.WriteAllText(FilePath, JsonSerializer.Serialize(_tasks));
            _sut = new TaskService(_tasks, FilePath);
        }

        [Test]
        public void AddTask_ShouldAddNewTask()
        {
            var taskName = "New Task";

            var newTask = _sut.AddTask(taskName);

            Assert.That(newTask.Id, Is.EqualTo(3));
            Assert.That(newTask.Description, Is.EqualTo(taskName));
            Assert.That(newTask.Status, Is.EqualTo(StatusEnum.ToDo));

            var savedTasks = JsonSerializer.Deserialize<List<WorkItem>>(File.ReadAllText(FilePath));
            Assert.That(savedTasks, Is.Not.Null);
            Assert.That(savedTasks, Has.Some.Matches<WorkItem>(t => t.Id == newTask.Id && t.Description == newTask.Description && t.Status == newTask.Status));
        }

        [Test]
        public void ListAllTasks_ShouldReturnAllTasks()
        {
            var tasks = _sut.ListAllTasks();

            Assert.That(tasks.Count(), Is.EqualTo(2));
        }

        [Test]
        public void RemoveTask_ShouldRemoveTaskById()
        {
            var taskId = "1";

            var removedTask = _sut.RemoveTask(taskId);

            Assert.That(removedTask?.Id, Is.EqualTo(1));
            Assert.That(_sut.ListAllTasks().Count() - 1, Is.EqualTo(1));
            Assert.That(_sut.FindWorkItem(1), Is.EqualTo(removedTask));

            var savedTasks = JsonSerializer.Deserialize<List<WorkItem>>(File.ReadAllText(FilePath));
            Assert.That(savedTasks, Is.Not.Null);
            Assert.That(savedTasks.Any(t => t.Id == 1), Is.True);
        }

        [Test]
        public void FindWorkItem_ShouldReturnCorrectTask()
        {
            var taskId = 2;

            var task = _sut.FindWorkItem(taskId);

            Assert.That(task, Is.Not.Null);
            Assert.That(task.Id, Is.EqualTo(taskId));
        }
    }
}