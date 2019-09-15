using Library.Helpers;
using Library.Simulation;
using Library.Tasks;
using System;
using System.Collections.Generic;
using System.IO;

namespace Library
{
    public static class Controller
    {
        /// <summary>
        /// Add Task
        /// if nomer not null void change task 
        /// </summary>
        public static void AddTask(int nomerTask = 0)
        {
            try
            {
                string NameTask;
                int TypeTask, ComplexityTask, Priority;
                bool pr = false;

                //Name
                System.Console.Write("\t Write Name Task: ");
                NameTask = System.Console.ReadLine();

                //Complexity
                do
                {
                    Console.Write("\t Write Complexity Task(from 1 to 5): ");
                    pr = int.TryParse(Console.ReadLine(), out ComplexityTask);
                    if (!(ComplexityTask >= 1 && ComplexityTask <= 5))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\t Write Complexity only from 1 to 5\tInvalid input. Try again:\n");
                        Console.ResetColor();
                        pr = false;
                    }
                } while (!pr);

                //Priority
                do
                {
                    Console.Write("\t Write Priority Task(from 1 to 5): ");
                    pr = int.TryParse(Console.ReadLine(), out Priority);
                    if (!(Priority >= 1 && Priority <= 5))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\t Write Priority only from 1 to 5\tInvalid input. Try again:\n");
                        Console.ResetColor();
                        pr = false;
                    }
                } while (!pr);

                if(nomerTask > 0)
                {
                    nomerTask--;
                    TaskRepository.Tasks[nomerTask].Name = NameTask;
                    TaskRepository.Tasks[nomerTask].Priority = Priority;
                    TaskRepository.Tasks[nomerTask].Complexity = ComplexityTask;
                    Console.WriteLine("\tTask successfully changed");
                }
                else
                {
                    //Type
                    do
                    {
                        Console.Write("\t Write Type Task(Bag:1, SomeTask:2, Technical debt: 3): ");
                        pr = int.TryParse(System.Console.ReadLine(), out TypeTask);
                        if (!(TypeTask >= 1 && TypeTask <= 3))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("\t Write Type only 1 or 2 or 3\tInvalid input. Try again:\n");
                            Console.ResetColor();
                            pr = false;
                        }
                    } while (!pr);
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
                    Console.WriteLine("\tSuccessfully Task Add");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\tError. Something went wrong!)", e.Message);
            }
        }
        /// <summary>
        /// Add Task
        /// </summary>
        public static void ChangeTask()
        {
            int _nomerTask;
            int index = 1;

            System.Console.WriteLine($"[index]\tId\t\t\t\t\tName\t\tPrioritet\tComplexityTask\tType_Task");
            //show tasks
            foreach (var task in TaskRepository.Tasks)
            {
                Console.WriteLine($"{index++,-8}{task.Id} [{task.Name}]\t{task.Priority,-5}\t\t{task.Complexity,-10}\t{task.GetType().Name}");
            }

            do
            {
                Console.Write("\t Write Task №:");
            } while (!Int32.TryParse(Console.ReadLine(), out _nomerTask));

            //int index = SomeTask.FindIndex(c => c.Name == SomeVariable);
            AddTask(_nomerTask--);
        }
        /// <summary>
        /// Show task
        /// </summary>
        /// <param name="index"></param>
        private static void ShowTask(int index = -1)
        {
            if (index == -1)
            {
                try
                {
                    for (int i = 0; i < TaskRepository.Tasks.Count; i++)
                    {
                        Console.WriteLine($"[{i + 1}]:{TaskRepository.Tasks[i].Name} ({TaskRepository.Tasks[i].GetType().Name}): priority - {TaskRepository.Tasks[i].Priority}, complexity - {TaskRepository.Tasks[i].Complexity}, status - {TaskRepository.Tasks[i].Status}");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("\tError. Something went wrong!)", e.Message);
                }
            }
            else if (index > -1 && index != 0)
            {
                try
                {
                    Console.WriteLine($"[{index + 1}]:{TaskRepository.Tasks[index--].Name} ({TaskRepository.Tasks[index--].GetType().Name}): priority - {TaskRepository.Tasks[index--].Priority}, complexity - {TaskRepository.Tasks[index].Complexity}:{TaskRepository.Tasks[index].Duration}, status - {TaskRepository.Tasks[index].Status}");

                }
                catch (Exception e)
                {
                    Console.WriteLine("\tError. Something went wrong!)", e.Message);
                }
            }
        }
        /// <summary>
        /// Show menu
        /// </summary>
        public static void ShowMenuInConsole()
        {
            Console.WriteLine("\n Please choose one of the options:");
            Console.WriteLine("\t [1] Add task");
            Console.WriteLine("\t [2] Change task");
            Console.WriteLine("\t [3] Show task");
            Console.WriteLine("\t [4] Show tasks");
            Console.WriteLine("\t [5] Simulation");
            Console.WriteLine("\t [6] Simulation result");
            Console.WriteLine("\t [7] History tasks");
            Console.WriteLine("\t [8] Clear console");
            Console.WriteLine("\t [9] Quit");
        }
        /// <summary>
        /// Jub with menu
        /// </summary>
        /// <param name="MQuit"></param>
        /// <param name="ChoiceNomMenu"></param>
        public static void JobWithMenu(ref bool MQuit, ref int ChoiceNomMenu)
        {
            while (!MQuit)
            {

                if (!Int32.TryParse(Console.ReadLine(), out ChoiceNomMenu) || !(ChoiceNomMenu >= 1 && ChoiceNomMenu <= 9))
                {
                    Console.WriteLine("\t Invalid input. Try again:");
                    ShowMenuInConsole();
                    continue;
                }

                switch (ChoiceNomMenu)
                {
                    case 1: //add task
                        Console.WriteLine("\t Insert the Task you want to add:");

                        AddTask();
                        //HistoryTaskAdd();
                        ShowMenuInConsole();

                        break;
                    case 2: //change task 

                        ChangeTask();
                        //HistoryTaskAdd();
                        ShowMenuInConsole();

                        break;
                    case 3: //show one task
                        Console.WriteLine("\t Show Task details");
                        ShowTask();

                        int index;
                        bool pr = false;
                        do
                        {
                            Console.Write("\t show index who show: ");
                            pr = int.TryParse(Console.ReadLine(), out index);
                        } while (!pr);

                        ShowTask(index);
                        ShowMenuInConsole();

                        break;
                    case 4: //show all tasks

                        ShowTask();
                        ShowMenuInConsole();
                        break;
                    case 5: //simulation

                        try
                        {
                            if(TaskRepository.Tasks.Count > 0)
                            {
                                int sim = 0;
                                do
                                {
                                    Console.Write("\t Choise Simulation: simulation - 1, random simulation - 2: ");
                                    pr = int.TryParse(Console.ReadLine(), out sim);
                                } while (!pr);
                                switch (sim)
                                {
                                    case 1:
                                        Console.WriteLine("\tSimulation started!");
                                        SimulationTasks.StartSimulation();
                                        break;
                                    case 2:
                                        Console.WriteLine("\tSimulation started!");
                                        SimulationTasks.StartRandomSimulation();
                                        break;
                                }
                                Console.WriteLine("\tSimulation end!");
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("\tError. Something went wrong!)", e.Message);
                        }

                        ShowMenuInConsole();
                        break;
                    case 6: // Simulation result
                        for(int x = 0; x < SimulationTasks.ResultSimulation.Count; x++)
                        {
                            ShowTask(SimulationTasks.ResultSimulation.IndexOf(SimulationTasks.ResultSimulation[x]));
                        }

                        ShowMenuInConsole();
                        break;
                    case 7: //History tasks
                        int i = 1;
                        foreach (var a in History())
                        {
                            Console.WriteLine($"{i}. {a}");
                            i++;
                        }

                        ShowMenuInConsole();
                        break;
                    case 8: //Clear console
                        Console.Clear();

                        ShowMenuInConsole();
                        break;
                    case 9:
                        //void WriteHistoryTasks
                        Console.WriteLine("\t Quitting...");
                        MQuit = true;
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
                foreach (string taskList in FileHelper.Read())
                {
                    String[] list = taskList.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var item in list)
                    {
                        String[] point = item.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        try
                        {
                            switch (int.Parse(point[4]))
                            {
                                case 1:
                                    tasks.Add(new Task(point[0], int.Parse(point[1]), int.Parse(point[2]), point[3]));
                                    break;
                                case 2:
                                    tasks.Add(new Task(point[0], int.Parse(point[1]), int.Parse(point[2]), point[3]));
                                    break;
                                case 3:
                                    tasks.Add(new TechnicalDebt(point[0], int.Parse(point[1]), int.Parse(point[2]), point[3]));
                                    break;
                                default:
                                    break;
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Something went wrong {ex.Message}");
                        }
                    }
                }
            }
            Console.WriteLine("List task was load from file");
            return tasks;
        }
    }
}
