namespace TaskManager;

class Program
{
    private TasksManager Manager = new("tasks.csv");
    public static async Task Main()
    {
        Program app = new();
        Console.WriteLine("Welcome to the Task Manager!");
        await app.Run();
    }

    private async Task Run()
    {
        Console.WriteLine("\n| Main Menu");
        Console.WriteLine("1. Add a task");
        Console.WriteLine("2. Remove a task");
        Console.WriteLine("3. List tasks");
        Console.WriteLine("4. Update a task");
        Console.WriteLine("5. Exit");
        Console.Write("Enter your choice: ");
        string? response = Console.ReadLine();
        switch (response)
        {
            case "1":
                AddTask();
                break;
            case "2":
                RemoveTask();
                break;
            case "3":
                ListTasks();
                break;
            case "4":
                UpdateTask();
                break;
            case "5":
                await Manager.SaveToFile();
                Console.WriteLine("\n| Goodbye and see you soon!");
                return;
            default:
                Console.WriteLine("Please enter a valid response.");
                break;
        }

        await Run();
    }

    private void AddTask()
    {
        Console.WriteLine("\n| Add a task");
        string taskName = ReadString("Enter the name of the task: ");
        string taskDescription = ReadString("Enter the description of the task: ");
        int taskCategory = ReadNumber("Enter the category of the task (1. Personal, 2. Work, 3. Errands, 4. Others): ", 1, 4);
        bool taskStatus = ReadBool("Is the task already completed? (y, n): ", "y", "n");

        Manager.AddTask(taskName, taskDescription, taskCategory, taskStatus);

        Console.WriteLine("Task added successfully!"); ;
    }

    private void RemoveTask()
    {
        if (Manager.NumberOfTasks == 0)
        {
            Console.WriteLine("There are no tasks to remove. Try adding first.");
            return;
        }

        Console.WriteLine("\n| Remove a task");
        Manager.ListTasks();
        int taskNumber = ReadNumber("Enter the number of the task to remove: ", 1, Manager.NumberOfTasks);
        Manager.RemoveTask(taskNumber);
        Console.WriteLine("Task removed successfully!");
    }

    private void UpdateTask()
    {
        if (Manager.NumberOfTasks == 0)
        {
            Console.WriteLine("There are no tasks to update. Try adding first.");
            return;
        }

        Console.WriteLine("\n| Update a task");
        Manager.ListTasks();
        int taskNumber = ReadNumber("Enter the number of the task to update: ", 1, Manager.NumberOfTasks);
        string taskName = ReadString("Enter a new name for the task (leave empty to not change): ", true);
        string taskDescription = ReadString("Enter a new description for the task (leave empty to not change): ", true);
        bool taskStatus = ReadBool("Is the task already completed? (y, n): ", "y", "n");

        Manager.UpdateTask(taskNumber, taskName, taskDescription, taskStatus);

        Console.WriteLine("Task updated successfully!");
        return;
    }

    private void ListTasks()
    {
        Console.WriteLine("\n| List of tasks");
        List<int> taskCategories = ReadList("Enter a category to filter the tasks.\n(1. Personal, 2. Work, 3. Errands, 4. Others. You can combine multiple categories with comma, leave empty for all.): ", 1, 5);
        if (taskCategories.Count > 0)
            Manager.ListTasks(taskCategories.ToArray());
        else
            Manager.ListTasks();
        return;
    }

    private static string ReadString(string prompt, bool canBeEmpty = false)
    {
        Console.Write(prompt);
        string? response = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(response) && !canBeEmpty)
        {
            Console.WriteLine("Please enter a valid response. It cannot be empty.");
            Console.Write(prompt);
            response = Console.ReadLine();
        }

        return response ?? "";
    }

    private static int ReadNumber(string prompt, int min, int max)
    {
        Console.Write(prompt);
        string? response = Console.ReadLine();
        int result;
        while (!int.TryParse(response, out result) || result < min || result > max)
        {
            Console.WriteLine("Please enter a valid response from the option range.");
            Console.Write(prompt);
            response = Console.ReadLine();
        }

        return result;
    }

    private static bool ReadBool(string prompt, string trueValue, string falseValue)
    {
        Console.Write(prompt);
        string? response = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(response) || response.ToLower() != trueValue && response.ToLower() != falseValue)
        {
            Console.WriteLine("Please enter a valid response from the given alternatives.");
            Console.Write(prompt);
            response = Console.ReadLine();
        }

        return response == trueValue;
    }

    private static List<int> ReadList(string prompt, int min, int max)
    {
        Console.Write(prompt);
        string? response = Console.ReadLine();

        try
        {
            List<int> result = new();
            string[] elements = response!.Split(", ");
            foreach (string element in elements)
            {
                result.Add(int.Parse(element));
            }
            return result;
        }
        catch
        {
            return new List<int>();
        }
    }

}