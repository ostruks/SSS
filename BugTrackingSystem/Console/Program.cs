using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Tasks;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowMenuInConsole();

            bool MQuit = false;

            int ChoiceNomMenu = 0;

            while (!MQuit)
            {

                if (!Int32.TryParse(System.Console.ReadLine(), out ChoiceNomMenu) || !(ChoiceNomMenu >= 1 && ChoiceNomMenu <= 6))
                {
                    System.Console.WriteLine("\t Invalid input. Try again:");
                    ShowMenuInConsole();
                    continue;
                }

                switch (ChoiceNomMenu)
                {
                    case 1:
                        System.Console.WriteLine("\t Insert the Task you want to add:");

                        AddTask();
                       //HistoryTaskAdd();
                        ShowMenuInConsole();

                        break;
                    case 2:

                        ChangeTask();
                        //HistoryTaskAdd();
                        ShowMenuInConsole();

                        break;
                    case 3:

                        //void Simulation
                        ShowMenuInConsole();

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

                        ShowMenuInConsole();
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

                        ShowMenuInConsole();
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

        /// <summary>
        /// Add Task
        /// </summary>
        private static void ChangeTask()
        {
            int _nomerTask;
            int index = 0;
            do
            {
                System.Console.Write("\t Write Task №:");
            } while (!Int32.TryParse(System.Console.ReadLine(), out _nomerTask));


            //System.Console.WriteLine($"[index] \t Id \t Name \t Prioritet \t ComplexityTask \t Type Task");
            ////show tasks
            //foreach (SomeTask task in SomeTaskLogicLayer.GetTasks)
            //{
            //    System.Console.WriteLine($"[{index++}] \t {task.Id} \t {task.Name} \t {task.Prioritet} \t {task.ComplexityTask} \t {task.TypeTask}");
            //}

            //int index = SomeTask.FindIndex(c => c.Name == SomeVariable);
            AddTask(_nomerTask);
        }

        /// <summary>
        /// Add Task
        /// if nomer not null void change task 
        /// </summary>
        private static void AddTask(int nomerTask = 0)
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
                    System.Console.Write("\t Write Type Task(Bag:1, SomeTask:2, Technical debt: 3):");
                    pr = int.TryParse(System.Console.ReadLine(), out TypeTask);
                    if (!(TypeTask >= 1 && TypeTask <= 3))
                    {
                        System.Console.ForegroundColor = ConsoleColor.Red;
                        System.Console.Write("\t Write Type only 1 or 2 or 3\tInvalid input. Try again:\n");
                        System.Console.ResetColor();
                        pr = false;
                    }
                } while (!pr);

                //if (nomerTask = 0)  ListTask.AddTask(new SomeTask(name: NameTask, complexity: ComplexityTask, typeTask: TypeTask));
                //else ListTask.ChangeTask(new SomeTask(name: NameTask, complexity: ComplexityTask, typeTask: TypeTask));

                System.Console.WriteLine("\tSuccessfully Task Add");
            }
            catch (Exception e)
            {
                System.Console.WriteLine("\tError. Something went wrong!)", e.Message);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        private static void ShowMenuInConsole()
        {
            System.Console.WriteLine("\n Please choose one of the options:");
            System.Console.WriteLine("\t [1] Add task");
            System.Console.WriteLine("\t [2] Change task");
            System.Console.WriteLine("\t [3] Simulation");
            System.Console.WriteLine("\t [4] History tasks");
            System.Console.WriteLine("\t [5] Clear console");
            System.Console.WriteLine("\t [6] Quit");
        }
    }
}
