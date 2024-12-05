# Task Tracker
Task Tracker is a simple console application to manage tasks. It allows you to add, list, and remove tasks, and stores them in a JSON file.

## Reference
https://roadmap.sh/projects/task-tracker

## Features

- Add new tasks
- List all tasks
- Remove tasks by ID
- Find tasks by ID

## Getting Started

### Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)

### Installation

1. Clone the repository:
    ```sh
    git clone https://github.com/TTranchese/task-tracker.git
    cd task-tracker
    ```

2. Build the project:
    ```sh
    dotnet build
    ```

3. Run the application:
    ```sh
    dotnet run --project tasktracker -- [command] [options]
    ```
### Usage

- To add a new task:
    ```sh
    dotnet run --project tasktracker [-a|--add] "New Task"
    ```

- To list all tasks:
    ```sh
    dotnet run --project tasktracker [-l|--list]
    ```

- To remove a task by ID:
    ```sh
    dotnet run --project tasktracker [-r|-remove] 1
    ```

- To change status to a task by ID:
    ```sh
    dotnet run --project tasktracker [-c|--change] 1 [ToDo|Pending|Complete]
    ```
- To print command list:
    ```sh
    dotnet run --project tasktracker [-h|--help]
    ```
