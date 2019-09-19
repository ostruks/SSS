using System;
using System.Collections.Generic;
using System.IO;
using Library.Interfaces;
using Library.Tasks;
using Newtonsoft.Json;

namespace Library.Helpers
{
    public class SaveFile : ISaveFile
    {
        private ReadFile _read = new ReadFile();
        public void SaveTxt(int Sprint)
        {
            string tasksFromFile = "";
            if (File.Exists("Tasks.txt"))
            {
                tasksFromFile = _read.Read("Tasks.txt");
                FileWrite(tasksFromFile, Sprint);
            }
            else
            {
                Sprint++;
                FileWrite(tasksFromFile, Sprint);
            }
        }

        private static void FileWrite(string read, int Sprint = -1)
        {
            foreach (var a in TaskRepository.Tasks)
            {
                if (Sprint > -1) a.Sprint = Sprint;
                read += $"{a.Sprint} {a.Name} {a.Priority} {a.Complexity} {a.Type} {a.Status}\n";
            }
            File.WriteAllText("Tasks.txt", read);
            Console.WriteLine("Tasks save!");
        }

        public void SaveJson(int Sprint)
        {
            List<BaseTask> tasks = new List<BaseTask>();
            if (File.Exists("Tasks.json"))
            {
                using (StreamReader file = File.OpenText("Tasks.json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    tasks = (List<BaseTask>)serializer.Deserialize(file, typeof(List<BaseTask>));

                    FileWriteJson(tasks, Sprint);
                }
            }
            else
            {
                Sprint++;
                FileWriteJson(tasks, Sprint);
            }
        }

        private static void FileWriteJson(List<BaseTask> tasks, int Sprint = -1)
        {
            foreach (var a in TaskRepository.Tasks)
            {
                if (Sprint > -1) a.Sprint = Sprint;
               
            }
            tasks.AddRange(TaskRepository.Tasks);
            using (StreamWriter file = File.CreateText("Tasks.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, TaskRepository.Tasks);
            }
            Console.WriteLine("Tasks save!");
        }
    }
}
