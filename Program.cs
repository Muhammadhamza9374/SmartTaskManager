using System;
using System.Collections.Generic;

class Program
{
    static TaskManager manager = new TaskManager();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\n===== SMART TASK MANAGER =====");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. View Tasks");
            Console.WriteLine("3. Mark Complete");
            Console.WriteLine("4. Delete Task");
            Console.WriteLine("5. Exit");
            Console.Write("Choose option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddTask();
                    break;

                case "2":
                    ViewTasks();
                    break;

                case "3":
                    CompleteTask();
                    break;

                case "4":
                    DeleteTask();
                    break;

                case "5":
                    Console.WriteLine("Goodbye!");
                    return;

                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }

    static void AddTask()
    {
        try
        {
            Console.Write("Enter Title: ");
            string title = Console.ReadLine();

            Console.Write("Enter Priority (Low/Medium/High): ");
            string priority = Console.ReadLine();

            PriorityTask task = new PriorityTask(
                manager.NextId(),
                title,
                priority
            );

            manager.AddTask(task);

            Console.WriteLine("Task Added Successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static void ViewTasks()
    {
        List<TaskItem> tasks = manager.GetTasks();

        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks found.");
            return;
        }

        Console.WriteLine("\n----- TASK LIST -----");

        foreach (TaskItem task in tasks)
        {
            Console.WriteLine(task.DisplayInfo());
        }
    }

    static void CompleteTask()
    {
        try
        {
            Console.Write("Enter Task ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            manager.MarkComplete(id);
        }
        catch
        {
            Console.WriteLine("Invalid ID.");
        }
    }

    static void DeleteTask()
    {
        try
        {
            Console.Write("Enter Task ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            manager.DeleteTask(id);
        }
        catch
        {
            Console.WriteLine("Invalid ID.");
        }
    }
}

class TaskItem
{
    public int TaskID { get; set; }
    public string Title { get; set; }
    public bool IsCompleted { get; set; }

    public TaskItem(int id, string title)
    {
        TaskID = id;
        Title = title;
        IsCompleted = false;
    }

    public virtual string DisplayInfo()
    {
        return TaskID + " | " + Title +
               " | " +
               (IsCompleted ? "Completed" : "Pending");
    }
}

class PriorityTask : TaskItem
{
    public string Priority { get; set; }

    public PriorityTask(int id, string title, string priority)
        : base(id, title)
    {
        Priority = priority;
    }

    public override string DisplayInfo()
    {
        return TaskID + " | " +
               Title + " | " +
               Priority + " | " +
               (IsCompleted ? "Completed" : "Pending");
    }
}

class TaskManager
{
    private List<TaskItem> tasks = new List<TaskItem>();

    public void AddTask(TaskItem task)
    {
        tasks.Add(task);
    }

    public List<TaskItem> GetTasks()
    {
        return tasks;
    }

    public int NextId()
    {
        return tasks.Count + 1;
    }

    public void DeleteTask(int id)
    {
        tasks.RemoveAll(t => t.TaskID == id);
        Console.WriteLine("Task Deleted.");
    }

    public void MarkComplete(int id)
    {
        foreach (TaskItem task in tasks)
        {
            if (task.TaskID == id)
            {
                task.IsCompleted = true;
                Console.WriteLine("Task Completed.");
                return;
            }
        }

        Console.WriteLine("Task Not Found.");
    }
}
