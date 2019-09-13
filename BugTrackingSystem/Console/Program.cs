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

                        try
                        {
                            //void AddTask
                            System.Console.WriteLine("\t Task added successfully.");
                        }
                        catch (Exception e)
                        {
                            System.Console.WriteLine("\tError. Something went wrong!)", e.Message);
                        }

                        ShowMenuInConsole();
                        break;
                    case 2:

                        try
                        {
                            //void ChangedTask
                            System.Console.WriteLine("\t Task changed successfully.");
                        }
                        catch (Exception e)
                        {
                            System.Console.WriteLine("\tError. Something went wrong!)", e.Message);
                        }

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
                            System.Console.WriteLine("\t Task changed successfully.");
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
                            System.Console.WriteLine("\t Task changed successfully.");
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
