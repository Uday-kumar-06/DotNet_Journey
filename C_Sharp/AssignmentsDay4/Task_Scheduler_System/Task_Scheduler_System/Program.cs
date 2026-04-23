using Task_Scheduler_System;

class Program
{
    public static void Main(string[] args)
    {
        TaskSchedular scheduler = new TaskSchedular();
        var tasks = scheduler.TaskAssgin();
        Queue<string> taskQueue = new Queue<string>();
        Stack<string> taskStack = new Stack<string>();
        List<string> taskList = new List<string>();

        scheduler.DisplayTasksInOrder(tasks, taskQueue, taskList);
        scheduler.ExecuteTasks(taskQueue, taskStack);
        scheduler.unDoingTasks(taskStack, taskQueue);
        Console.WriteLine("Tasks left after undo:");
        foreach (var task in taskQueue)
        {
            Console.WriteLine(task);
        }
    }
}