using System;
using System.Collections.Generic;
using System.Text;

namespace Task_Scheduler_System
{
    internal class TaskSchedular
    {

        public SortedDictionary<int, string> TaskAssgin()
        {
            SortedDictionary<int, string> orderedTasks = new SortedDictionary<int, string>();
            HashSet<string> taskNameSet = new HashSet<string>();
            HashSet<int> taskPrioritySet = new HashSet<int>();
            while (true)
            {
                Console.WriteLine("Enter 1 to add a task, 2 to exit:");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.WriteLine("Enter Task Name:");
                        string taskName = Console.ReadLine();
                        if (taskNameSet.Contains(taskName))
                        {
                            Console.WriteLine("Task name already exists. Please enter a unique task name.");
                            break;
                        }
                        taskNameSet.Add(taskName);
                        Console.WriteLine("Enter Task Priority (integer):");
                        int priority = int.Parse(Console.ReadLine());
                        if (taskPrioritySet.Contains(priority))
                        {
                            Console.WriteLine("Task priority already exists. Please enter a unique task priority.");
                            break;
                        }
                        taskPrioritySet.Add(priority);
                        orderedTasks[priority] = taskName;
                        break;
                    case "2":
                        return orderedTasks;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }

            }

            return orderedTasks;
        }


        public void DisplayTasksInOrder(SortedDictionary<int, string> tasks, Queue<string> taskQueue, List<string> tasksList)
        {
            Console.WriteLine("Tasks in order of execution:");
            foreach (var task in tasks)
            {
                Console.WriteLine($"Priority: {task.Key}, Task: {task.Value}");
                taskQueue.Enqueue(task.Value);
                tasksList.Add(task.Value);
            }
        }

        public void ExecuteTasks(Queue<string> taskQueue, Stack<string> taskStack)
        {
            Console.WriteLine("Executing tasks in order:");
            while (taskQueue.Count > 0)
            {
                string task = taskQueue.Dequeue();
                taskStack.Push(task);
                Console.WriteLine($"Executing Task: {task}");
            }
        }


        public void unDoingTasks(Stack<string> taskStack, Queue<string> taskQueue)
        {
            Console.WriteLine("Undoing tasks in reverse order:");
            Console.WriteLine("Enter number of tasks you want to undo:");
            if (int.TryParse(Console.ReadLine(), out int undoCount))
            {
                for (int i = 0; i < undoCount && taskStack.Count > 0; i++)
                {
                    string task = taskStack.Pop();
                    taskQueue.Enqueue(task);
                    Console.WriteLine($"Undoing Task: {task}");
                }
            }
            else
            {
                Console.WriteLine("Invalid number. Please enter an integer.");
            }
        }
    }
}
