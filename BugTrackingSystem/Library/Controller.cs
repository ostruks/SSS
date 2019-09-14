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
            foreach (TechnicalDebt task in TechnicalDebtLogic.GetTechnicalDebts)
            {
                System.Console.WriteLine($"{index++,-8}{task.Id} [{task.Name}]\t{task.Priority,-5}\t\t{task.Complexity,-10}\t{task.GetType()}");
            }

            do
            {
                System.Console.Write("\t Write Task №:");
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
        public static void ShowMenuInConsole()
        {
            System.Console.WriteLine("\n Please choose one of the options:");
            System.Console.WriteLine("\t [1] Add task");
            System.Console.WriteLine("\t [2] Change task");
            System.Console.WriteLine("\t [3] Simulation");
            System.Console.WriteLine("\t [4] History tasks");
            System.Console.WriteLine("\t [5] Clear console");
            System.Console.WriteLine("\t [6] Quit");
        }
        public static void AddNEWListForExample()
        {
            TechnicalDebtLogic.AddTechnicalDebt(new TechnicalDebt("Hejlsberg", 5, 6));
        }
    }
}
