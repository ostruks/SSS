using Library.Tasks;
using System;

namespace Library
{
    public static class Controller
    {
        /// <summary>
        /// Add Task
        /// </summary>
        public static void ChangeTask()
        {
            int _nomerTask;
            int index = 0;

            System.Console.WriteLine($"[index]\tId\t\t\t\t\tName\t\tPrioritet\tComplexityTask\tType_Task");
            //show tasks
            foreach (var task in TaskRepository.Tasks)
            {
                Console.WriteLine($"{index++,-8}{task.Id} [{task.Name}]\t{task.Priority,-5}\t\t{task.Complexity,-10}\t{task.GetType()}");
            }

            do
            {
                Console.Write("\t Write Task №:");
            } while (!Int32.TryParse(System.Console.ReadLine(), out _nomerTask));

            //int index = SomeTask.FindIndex(c => c.Name == SomeVariable);
            AddTask(_nomerTask);
        }

        /// <summary>
        /// Add Task
        /// if nomer not null void change task 
        /// </summary>
        public static void AddTask(int nomerTask = 0)
        {
            try
            {
                string NameTask;
                int TypeTask, ComplexityTask;
                bool pr = false;

                //Name
                System.Console.Write("\t Write Name Task:");
                NameTask = System.Console.ReadLine();

                //Complexity
                do
                {
                    System.Console.Write("\t Write Complexity Task(from 1 to 5):");
                    pr = int.TryParse(System.Console.ReadLine(), out ComplexityTask);
                    if (!(ComplexityTask >= 1 && ComplexityTask <= 5))
                    {
                        System.Console.ForegroundColor = ConsoleColor.Red;
                        System.Console.Write("\t Write Complexity only from 1 to 5\tInvalid input. Try again:\n");
                        System.Console.ResetColor();
                        pr = false;
                    }
                } while (!pr);

                //Type
                do
                {
                    Console.Write("\t Write Type Task(Bag:1, SomeTask:2, Technical debt: 3):");
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
                    case 2:
                        TaskRepository.AddTask(new Task(NameTask, 1, ComplexityTask));
                        break;
                    case 3:
                        TaskRepository.AddTask(new TechnicalDebt(NameTask, 1, ComplexityTask));
                        break;
                }

                Console.WriteLine("\tSuccessfully Task Add");
            }
            catch (Exception e)
            {
                Console.WriteLine("\tError. Something went wrong!)", e.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static void ShowMenuInConsole()
        {
            Console.WriteLine("\n Please choose one of the options:");
            Console.WriteLine("\t [1] Add task");
            Console.WriteLine("\t [2] Change task");
            Console.WriteLine("\t [3] Simulation");
            Console.WriteLine("\t [4] History tasks");
            Console.WriteLine("\t [5] Clear console");
            Console.WriteLine("\t [6] Quit");
        }

        public static void JobWithMenu(ref bool MQuit, ref int ChoiceNomMenu)
        {
            while (!MQuit)
            {

                if (!Int32.TryParse(System.Console.ReadLine(), out ChoiceNomMenu) || !(ChoiceNomMenu >= 1 && ChoiceNomMenu <= 6))
                {
                    System.Console.WriteLine("\t Invalid input. Try again:");
                    Controller.ShowMenuInConsole();
                    continue;
                }

                switch (ChoiceNomMenu)
                {
                    case 1:
                        System.Console.WriteLine("\t Insert the Task you want to add:");

                        Controller.AddTask();
                        //HistoryTaskAdd();
                        Controller.ShowMenuInConsole();

                        break;
                    case 2:

                        Controller.ChangeTask();
                        //HistoryTaskAdd();
                        Controller.ShowMenuInConsole();

                        break;
                    case 3:

                        //void Simulation
                        Controller.ShowMenuInConsole();

                        break;
                    case 4:

                        try
                        {
                            //void ReadHistoryTasks
                        }
                        catch (Exception e)
                        {
                            System.Console.WriteLine("\tError. Something went wrong!)", e.Message);
                        }

                        Controller.ShowMenuInConsole();
                        break;
                    case 5:

                        try
                        {
                            //void ClearConsole
                            System.Console.WriteLine("\t Tasks clear successfully.");
                        }
                        catch (Exception e)
                        {
                            System.Console.WriteLine("\tError. Something went wrong!)", e.Message);
                        }

                        Controller.ShowMenuInConsole();
                        break;
                    case 6:
                        //void WriteHistoryTasks
                        System.Console.WriteLine("\t Quitting...");
                        MQuit = true;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
