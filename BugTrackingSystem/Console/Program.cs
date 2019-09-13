using System;
using Library;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Controller.ShowMenuInConsole();
            Controller.AddNEWListForExample();

            bool MQuit = false;
            int ChoiceNomMenu = 0;

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