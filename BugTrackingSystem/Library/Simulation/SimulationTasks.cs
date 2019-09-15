using Library.Tasks;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Library.Simulation
{
    public static class SimulationTasks
    {
        private static List<BaseTask> Result = new List<BaseTask>();
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
                    Console.WriteLine(TaskRepository.Tasks[i]);
                    TaskRepository.Tasks[i].Status = "Done";
                    Result.Add(TaskRepository.Tasks[i]);
                    Thread.Sleep(TimeSpan.FromSeconds(4));
                    Console.WriteLine(TaskRepository.Tasks[i]);
                }
                else
                {
                    TaskRepository.Tasks[i].Status = "BackLog";
                    Result.Add(TaskRepository.Tasks[i]);
                }
            }
        }

        public static void StartRandomSimulation()
        {
            Result.Clear();
            const double iterations = 30;
            double doneIterations = 0;
            Random random = new Random();
            string[] statuses = new string[] { "BackLog", "Done" };

            for (int i = 0; i < TaskRepository.Tasks.Count; i++)
            {
                doneIterations += TaskRepository.Tasks[i].Duration;
                if (doneIterations <= iterations)
                {
                    Console.WriteLine(TaskRepository.Tasks[i]);
                    TaskRepository.Tasks[i].Status = statuses[random.Next(0, 1)];
                    Result.Add(TaskRepository.Tasks[i]);
                    Thread.Sleep(TimeSpan.FromSeconds(4));
                    Console.WriteLine(TaskRepository.Tasks[i]);
                }
                else
                {
                    TaskRepository.Tasks[i].Status = "BackLog";
                    Result.Add(TaskRepository.Tasks[i]);
                }
            }
        }

        public static List<BaseTask> ResultSimulation {
            get {
                return Result;
            }
        }
    }
}
