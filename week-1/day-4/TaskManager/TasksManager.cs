using System.IO;
using TaskManager.Commons.Enums;

namespace TaskManager;

class TasksManager
{
    private readonly List<UnitTask> tasks = new();
    private readonly string _filePath;
    public int NumberOfTasks
    {
        get => tasks.Count;
    }

    public TasksManager(string filePath)
    {
        _filePath = filePath;
        _ = ReadFromFile();
    }

    private async Task ReadFromFile()
    {
        Console.WriteLine("\n| Reading your tasks from file...");
        using StreamReader reader = new(_filePath);
        string? line;
        while ((line = await reader.ReadLineAsync()) != null)
        {
            try
            {
                string[] values = line.Split(',');
                UnitTask task = new()
                {
                    Name = values[0],
                    Description = values[1],
                    Category = (UnitTaskEnum)int.Parse(values[2]),
                    IsCompleted = bool.Parse(values[3])
                };

                tasks.Add(task);
            }
            catch
            {
                Console.WriteLine("Error reading task from file.");
            }
        }
    }

    public async Task SaveToFile()
    {
        Console.WriteLine("\n| Saving your tasks to file...");
        using StreamWriter writer = new(_filePath);
        foreach (UnitTask task in tasks)
        {
            await writer.WriteLineAsync(task.ToCSV());
        }
    }

    public void AddTask(string name, string description, int category, bool isCompleted)
    {
        // Category are powers of 2 so we need to change the int we get to the corresponding enum
        UnitTaskEnum taskCategory = (UnitTaskEnum)Math.Pow(2, category - 1);
        UnitTask task = new() { Name = name, Description = description, Category = taskCategory, IsCompleted = isCompleted };
        tasks.Add(task);
    }

    public void RemoveTask(int index)
    {
        tasks.RemoveAt(index - 1);
    }

    public void ListTasks()
    {
        // List the tasks with numbers
        int rollNumber = 1;
        foreach (UnitTask task in tasks)
        {
            Console.WriteLine($"{rollNumber}. {task}");
            rollNumber++;
        }
    }


    public void ListTasks(params int[] categories)
    {
        UnitTaskEnum taskCategory = (UnitTaskEnum)categories.Aggregate(0, (current, category) => current | (int)Math.Pow(2, category - 1));
        List<UnitTask> filteredTasks = tasks.Where(task => (task.Category & taskCategory) == task.Category).ToList();

        // List the tasks with numbers
        int rollNumber = 1;
        foreach (UnitTask task in filteredTasks)
        {
            Console.WriteLine($"{rollNumber}. {task}");
            rollNumber++;
        }
    }

    public void UpdateTask(int index, string? name, string? description, bool? isCompleted)
    {
        UnitTask task = tasks[index - 1];
        if (!string.IsNullOrEmpty(name))
        {
            task.Name = name;
        }

        if (!string.IsNullOrEmpty(description))
        {
            task.Description = description;
        }

        if (isCompleted != null)
        {
            task.IsCompleted = (bool)isCompleted;
        }
    }
}