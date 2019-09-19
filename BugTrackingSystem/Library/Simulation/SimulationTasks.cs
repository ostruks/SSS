using Library.Helpers;
using Library.Tasks;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Library.Simulation
{
    public static class SimulationTasks
    {
        private static List<BaseTask> Result = new List<BaseTask>();

        /// <summary>
        /// Simulation result
        /// </summary>
        public static List<BaseTask> ResultSimulation
        {
            get
            {
                return Result;
            }
        }

        /// <summary>
        /// Start simulation the activities
        /// </summary>
        public static void StartSimulation()
        {
            Result.Clear();
            const double iterations = 30;
            double doneIterations = 0;
            for ( int i = 0; i < TaskRepository.Tasks.Count; i++)
            {
                doneIterations += TaskRepository.Tasks[i].Duration;
                if (doneIterations <= iterations)
                {
                    Console.ForegroundColor = (ConsoleColor)ConsoleColors.EnumConsoleColors.ErrorOrOther;
                    Console.WriteLine(TaskRepository.Tasks[i].Display());
                    Thread.Sleep(TimeSpan.FromSeconds(2));
                    TaskRepository.Tasks[i].Status = "In Progress";
                    Console.ForegroundColor = (ConsoleColor)ConsoleColors.EnumConsoleColors.Info;
                    Console.WriteLine(TaskRepository.Tasks[i].Display());
                    Thread.Sleep(TimeSpan.FromSeconds(2));
                    TaskRepository.Tasks[i].Status = "Done";
                    Result.Add(TaskRepository.Tasks[i]);
                    Thread.Sleep(TimeSpan.FromSeconds(2));
                    Console.ForegroundColor = (ConsoleColor)ConsoleColors.EnumConsoleColors.MenuItems;
                    Console.WriteLine(TaskRepository.Tasks[i].Display());
                    Thread.Sleep(TimeSpan.FromSeconds(2));
                }
                else
                {
                    TaskRepository.Tasks[i].Status = "BackLog";
                    Result.Add(TaskRepository.Tasks[i]);
                }
            }
        }

        /// <summary>
        /// Start random simulation the activities
        /// </summary>
        public static void StartRandomSimulation()
        {
            Result.Clear();
            const double iterations = 30;
            double doneIterations = 0;
            Random random = new Random();
            string[] statuses = new string[] { "BackLog", "Done", "in progress" };

            for (int i = 0; i < TaskRepository.Tasks.Count; i++)
            {
                doneIterations += TaskRepository.Tasks[i].Duration;
                if (doneIterations <= iterations)
                {
                    Console.ForegroundColor = (ConsoleColor)ConsoleColors.EnumConsoleColors.ErrorOrOther;
                    Console.WriteLine(TaskRepository.Tasks[i].Display());
                    TaskRepository.Tasks[i].Status = "In Progress";
                    Thread.Sleep(TimeSpan.FromSeconds(2));
                    Console.ForegroundColor = (ConsoleColor)ConsoleColors.EnumConsoleColors.Info;
                    Console.WriteLine(TaskRepository.Tasks[i].Display());
                    Thread.Sleep(TimeSpan.FromSeconds(2));
                    TaskRepository.Tasks[i].Status = statuses[random.Next(0, 2)];
                    Result.Add(TaskRepository.Tasks[i]);
                    Thread.Sleep(TimeSpan.FromSeconds(2));
                    Console.ForegroundColor = (ConsoleColor)ConsoleColors.EnumConsoleColors.MenuItems;
                    Console.WriteLine(TaskRepository.Tasks[i].Display());
                    Thread.Sleep(TimeSpan.FromSeconds(2));
                }
                else
                {
                    TaskRepository.Tasks[i].Status = "BackLog";
                    Result.Add(TaskRepository.Tasks[i]);
                }
            }
        }
    }
}
