using Library.Helpers;
using Library.Log;
using Library.Simulation;
using Library.Tasks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace Library
{
    public static class Controller
    {
        /// <summary>
        /// For adding number of sprint
        /// </summary>
        private static int _sprint = 0;

        /// <summary>
        /// For saving simulation result in file
        /// </summary>
        private static SaveFile _save = new SaveFile();

        /// <summary>
        /// enum for using menu
        /// </summary>
        public enum MenuItem
        {
            [Description("\n Please choose one of the options:")]
            None = 0,
            [Description("\t [1] Add task")]
            AddTask = 1,
            [Description("\t [2] Change task")]
            ChangeTask = 2,
            [Description("\t [3] Show tasks")]
            ShowTask = 3,
            [Description("\t [4] Show tasks")]
            ShowTasks = 4,
            [Description("\t [5] Simulation")]
            Simulation = 5,
            [Description("\t [6] Simulation result")]
            SimulationResult = 6,
            [Description("\t [7] History tasks")]
            HistoryTasks = 7,
            [Description("\t [8] Clear repository")]
            ClearRepository = 8,
            [Description("\t [9] Clear console")]
            ClearConsole = 9,
            [Description("\t [10] Quit")]
            Quit = 10
        }

        /// <summary>
        /// Show menu
        /// </summary>
        public static void ShowMenuInConsole()
        {
            foreach (MenuItem item in Enum.GetValues(typeof(MenuItem)))
            {
                if (item == 0) Console.ForegroundColor = (ConsoleColor)ConsoleColors.EnumConsoleColors.MenuNameColor;
                else Console.ForegroundColor = (ConsoleColor)ConsoleColors.EnumConsoleColors.MenuItems;
                Console.WriteLine(item.GetDescription());
            }
        }

        /// <summary>
        /// GetDescription Enum
        /// extension method (this Enum value)
        /// </summary>
        /// <param name="value">Enum type</param>
        /// <returns></returns>
        public static string GetDescription(this Enum value)
        {
            var descriptionAttribute = (DescriptionAttribute)value.GetType()
                .GetField(value.ToString())
                .GetCustomAttributes(false)
                .Where(a => a is DescriptionAttribute)
                .FirstOrDefault();

            return descriptionAttribute != null ? descriptionAttribute.Description : value.ToString();
        }

        /// <summary>
        /// Add Task
        /// if nomer not null void change task 
        /// </summary>
        public static void AddTask(int nomerTask = 0)
        {
            AddOrChange(nomerTask);
        }

        /// <summary>
        /// Add Task
        /// </summary>
        public static void ChangeTask()
        {
            if (TaskRepository.Tasks.Count > 0)
            {
                int _nomerTask;
                int index = 1;

                Console.ForegroundColor = (ConsoleColor)ConsoleColors.EnumConsoleColors.MenuNameColor;
                System.Console.WriteLine($"[index]\tId\t\t\t\t\tName\t\tPrioritet\tComplexityTask\tType_Task");
                //show tasks
                Console.ForegroundColor = (ConsoleColor)ConsoleColors.EnumConsoleColors.MenuItems;
                foreach (var task in TaskRepository.Tasks)
                {
                    Console.WriteLine($"{index++,-8}{task.Id} \t[{task.Name}]\t{task.Priority,-5}\t\t{task.Complexity,-10}\t{task.GetType().Name}");
                }

                do
                {
                    Console.ForegroundColor = (ConsoleColor)ConsoleColors.EnumConsoleColors.MenuNameColor;
                    Console.Write("\t Write task numbers:");
                } while (!Int32.TryParse(Console.ReadLine(), out _nomerTask));

                //int index = SomeTask.FindIndex(c => c.Name == SomeVariable);
                AddTask(_nomerTask--);
            }
            else
            {
                Console.ForegroundColor = (ConsoleColor)ConsoleColors.EnumConsoleColors.ErrorOrOther;
                Console.Write("\tTask repository is empty!");
            }
        }

        /// <summary>
        /// Add or change task
        /// </summary>
        /// <param name="nomerTask">number of task</param>
        /// <returns></returns>
        private static void AddOrChange(int nomerTask)
        {
            try
            {
                string NameTask;
                int TypeTask, ComplexityTask, Priority;
                bool pr = false;

                //Name
                Console.ForegroundColor = (ConsoleColor)ConsoleColors.EnumConsoleColors.MenuItems;
                System.Console.Write("\t Write Name Task: ");
                NameTask = System.Console.ReadLine();

                //Complexity
                do
                {
                    Console.ForegroundColor = (ConsoleColor)ConsoleColors.EnumConsoleColors.MenuItems;
                    Console.Write("\t Write Complexity Task(from 1 to 5): ");
                    pr = int.TryParse(Console.ReadLine(), out ComplexityTask);
                    if (!(ComplexityTask >= 1 && ComplexityTask <= 5))
                    {
                        Console.ForegroundColor = (ConsoleColor)ConsoleColors.EnumConsoleColors.Info;
                        Console.Write("\t Write Complexity only from 1 to 5\tInvalid input. Try again:\n");
                        Console.ResetColor();
                        pr = false;
                    }
                } while (!pr);

                //Priority
                do
                {
                    Console.ForegroundColor = (ConsoleColor)ConsoleColors.EnumConsoleColors.MenuItems;
                    Console.Write("\t Write Priority Task(from 1 to 5): ");
                    pr = int.TryParse(Console.ReadLine(), out Priority);
                    if (!(Priority >= 1 && Priority <= 5))
                    {
                        Console.ForegroundColor = (ConsoleColor)ConsoleColors.EnumConsoleColors.Info;
                        Console.Write("\t Write Priority only from 1 to 5\tInvalid input. Try again:\n");
                        Console.ResetColor();
                        pr = false;
                    }
                } while (!pr);

                //Type
                do
                {
                    Console.ForegroundColor = (ConsoleColor)ConsoleColors.EnumConsoleColors.MenuItems;
                    Console.Write("\t Write Type Task(Bag:1, Task:2, Technical debt: 3): ");
                    pr = int.TryParse(System.Console.ReadLine(), out TypeTask);
                    if (!(TypeTask >= 1 && TypeTask <= 3))
                    {
                        Console.ForegroundColor = (ConsoleColor)ConsoleColors.EnumConsoleColors.Info;
                        Console.Write("\t Write Type only 1 or 2 or 3\tInvalid input. Try again:\n");
                        Console.ResetColor();
                        pr = false;
                    }
                } while (!pr);

                if (nomerTask > 0)
                {
                    nomerTask--;
                    string status = TaskRepository.Tasks[nomerTask].Status;
                    switch (TypeTask)
                    {
                        case 1:
                            TaskRepository.Tasks[nomerTask] = new Bug(NameTask, Priority, ComplexityTask, status);
                            break;
                        case 2:
                            TaskRepository.Tasks[nomerTask] = new Task(NameTask, Priority, ComplexityTask, status);
                            break;
                        case 3:
                            TaskRepository.Tasks[nomerTask] = new TechnicalDebt(NameTask, Priority, ComplexityTask, status);
                            break;
                        default:
                            break;
                    }
                    Console.ForegroundColor = (ConsoleColor)ConsoleColors.EnumConsoleColors.MenuNameColor;
                    Console.WriteLine("\tTask successfully changed");
                }
                else
                {
                    //Add Task
                    switch (TypeTask)
                    {
                        case 1:
                            TaskRepository.AddTask(new Bug(NameTask, Priority, ComplexityTask, "BackLog"));
                            break;
                        case 2:
                            TaskRepository.AddTask(new Task(NameTask, Priority, ComplexityTask, "BackLog"));
                            break;
                        case 3:
                            TaskRepository.AddTask(new TechnicalDebt(NameTask, Priority, ComplexityTask, "BackLog"));
                            break;
                        default:
                            break;
                    }
                    Console.ForegroundColor = (ConsoleColor)ConsoleColors.EnumConsoleColors.Info;
                    Console.WriteLine("\tSuccessfully Task Add");
                }
            }
            catch (Exception e)
            {
                Console.ForegroundColor = (ConsoleColor)ConsoleColors.EnumConsoleColors.ErrorOrOther;
                Console.WriteLine("\tError. Something went wrong!)", e.Message);
                LogMsg.WriteLog(e.Message);
            }
        }

        /// <summary>
        /// Show task
        /// </summary>
        /// <param name="index">index for showing one task</param>
        private static void ShowTask(int index = -1)
        {
            if (index == -1)
            {
                try
                {
                    if (TaskRepository.Tasks.Count > 0)
                    {
                        Console.ForegroundColor = (ConsoleColor)ConsoleColors.EnumConsoleColors.Info;
                        for (int i = 0; i < TaskRepository.Tasks.Count; i++)
                        {
                            Console.WriteLine($"[{i + 1}]: {TaskRepository.Tasks[i].Display()}");
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = (ConsoleColor)ConsoleColors.EnumConsoleColors.ErrorOrOther;
                        Console.WriteLine("\tIs no tasks!");
                    }
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = (ConsoleColor)ConsoleColors.EnumConsoleColors.ErrorOrOther;
                    Console.WriteLine("\tError. Something went wrong!)", e.Message);
                    LogMsg.WriteLog(e.Message);
                }
            }
            else if (index > -1 && index != 0)
            {
                try
                {
                    index--;
                    Console.ForegroundColor = (ConsoleColor)ConsoleColors.EnumConsoleColors.Info;
                    Console.WriteLine($"[{index + 1}]: {TaskRepository.Tasks[index].Display()}");

                }
                catch (Exception e)
                {
                    Console.ForegroundColor = (ConsoleColor)ConsoleColors.EnumConsoleColors.ErrorOrOther;
                    Console.WriteLine("\tError. Something went wrong!)", e.Message);
                    LogMsg.WriteLog(e.Message);
                }
            }
        }

        /// <summary>
        /// Jub with menu
        /// </summary>
        public static void JobWithMenu()
        {

            bool mQuit = false;
            int choiceNomMenu = 0;

            Controller.ShowMenuInConsole();

            while (!mQuit)
            {

                if (!Int32.TryParse(Console.ReadLine(), out choiceNomMenu) || !(choiceNomMenu >= 1 && choiceNomMenu <= 10))
                {
                    Console.ForegroundColor = (ConsoleColor)ConsoleColors.EnumConsoleColors.ErrorOrOther;
                    Console.WriteLine("\t Invalid input. Try again:");
                    ShowMenuInConsole();
                    continue;
                }

                switch (choiceNomMenu)
                {
                    case (int)MenuItem.AddTask:
                        Console.ForegroundColor = (ConsoleColor)ConsoleColors.EnumConsoleColors.MenuNameColor;
                        Console.WriteLine("\t Insert the Task you want to add:");

                        AddTask();

                        ShowMenuInConsole();

                        break;
                    case (int)MenuItem.ChangeTask:

                        ChangeTask();
                        //HistoryTaskAdd();
                        ShowMenuInConsole();

                        break;
                    case 3: //show one task
                        Console.ForegroundColor = (ConsoleColor)ConsoleColors.EnumConsoleColors.MenuNameColor;
                        Console.WriteLine("\t Show Task details");
                        ShowTask();

                        int index;
                        bool pr = false;
                        do
                        {
                            Console.ForegroundColor = (ConsoleColor)ConsoleColors.EnumConsoleColors.ErrorOrOther;
                            Console.Write("\t show index who show: ");
                            pr = int.TryParse(Console.ReadLine(), out index);
                        } while (!pr);

                        ShowTask(index);
                        ShowMenuInConsole();

                        break;
                    case 4: //show all tasks
                        Console.ForegroundColor = (ConsoleColor)ConsoleColors.EnumConsoleColors.MenuNameColor;

                        ShowTask();
                        ShowMenuInConsole();
                        break;
                    case 5: //simulation

                        try
                        {
                            if (TaskRepository.Tasks.Count > 0)
                            {
                                int sim = 0;
                                do
                                {
                                    Console.ForegroundColor = (ConsoleColor)ConsoleColors.EnumConsoleColors.MenuNameColor;
                                    Console.Write("\t Choise Simulation: simulation - 1, random simulation - 2: ");
                                    pr = int.TryParse(Console.ReadLine(), out sim);
                                } while (!pr);
                                switch (sim)
                                {
                                    case 1:
                                        Console.ForegroundColor = (ConsoleColor)ConsoleColors.EnumConsoleColors.Info;
                                        Console.WriteLine("\tSimulation started!");
                                        SimulationTasks.StartSimulation();
                                        break;
                                    case 2:
                                        Console.ForegroundColor = (ConsoleColor)ConsoleColors.EnumConsoleColors.Info;
                                        Console.WriteLine("\tSimulation started!");
                                        SimulationTasks.StartRandomSimulation();
                                        break;
                                }
                                Console.ForegroundColor = (ConsoleColor)ConsoleColors.EnumConsoleColors.MenuNameColor;
                                Console.WriteLine("\tSimulation end!");
                            }
                        }
                        catch (Exception e)
                        {
                            Console.ForegroundColor = (ConsoleColor)ConsoleColors.EnumConsoleColors.ErrorOrOther;
                            Console.WriteLine("\tError. Something went wrong!)", e.Message);
                            LogMsg.WriteLog(e.Message);
                        }

                        _sprint++;
                        _save.SaveTxt(_sprint);

                        ShowMenuInConsole();
                        break;
                    case 6: // Simulation result
                        Console.ForegroundColor = (ConsoleColor)ConsoleColors.EnumConsoleColors.MenuNameColor;
                        if (SimulationTasks.ResultSimulation.Count == 0)
                        {
                            Console.ForegroundColor = (ConsoleColor)ConsoleColors.EnumConsoleColors.ErrorOrOther;
                            Console.WriteLine("\tIs no finished simulations!");
                        }
                        else
                        {
                            for (int x = 0; x < SimulationTasks.ResultSimulation.Count; x++)
                            {
                                ShowTask(x + 1);
                            }
                        }

                        ShowMenuInConsole();
                        break;
                    case 7: //History tasks
                        Console.ForegroundColor = (ConsoleColor)ConsoleColors.EnumConsoleColors.Info;
                        int i = 1;
                        foreach (var a in History())
                        {
                            Console.WriteLine($"Sprint: {a.Sprint} [{i}] {a.Display()}");
                            i++;
                        }

                        ShowMenuInConsole();
                        break;
                    case 8: //Clear Repository
                        TaskRepository.Tasks.Clear();
                        Console.ForegroundColor = (ConsoleColor)ConsoleColors.EnumConsoleColors.ErrorOrOther;
                        Console.WriteLine("Repository cleared!");

                        ShowMenuInConsole();
                        break;
                    case 9: //Clear console
                        Console.Clear();

                        ShowMenuInConsole();
                        break;
                    case 10:
                        //void WriteHistoryTasks
                        Console.ForegroundColor = (ConsoleColor)ConsoleColors.EnumConsoleColors.MenuItems;
                        Console.WriteLine("\t Quitting...");
                        mQuit = true;
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// History of stories
        /// </summary>
        /// <returns></returns>
        public static List<BaseTask> History()
        {
            List<BaseTask> tasks = new List<BaseTask>();
            if (File.Exists("tasks.txt"))
            {
                foreach (string taskList in new ReadFile().Read())
                {
                    String[] list = taskList.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var item in list)
                    {
                        String[] point = item.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        try
                        {
                            switch (point[4])
                            {
                                case "Bug":
                                    tasks.Add(new Bug(point[1], int.Parse(point[2]), int.Parse(point[3]), point[5]) { Sprint = int.Parse(point[0]) });
                                    break;
                                case "Task":
                                    tasks.Add(new Task(point[1], int.Parse(point[2]), int.Parse(point[3]), point[5]) { Sprint = int.Parse(point[0]) });
                                    break;
                                case "TechnicalDebt":
                                    tasks.Add(new TechnicalDebt(point[1], int.Parse(point[2]), int.Parse(point[3]), point[5]) { Sprint = int.Parse(point[0]) });
                                    break;
                                default:
                                    break;
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Something went wrong {ex.Message}");
                            LogMsg.WriteLog(ex.Message);
                        }
                    }
                }
                Console.WriteLine("List task was load from file");
            }
            else
            {
                Console.ForegroundColor = (ConsoleColor)ConsoleColors.EnumConsoleColors.ErrorOrOther;
                Console.WriteLine("File is not exist!");
            }
            return tasks;
        }
    }
}
