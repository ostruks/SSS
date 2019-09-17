using Library.Tasks;
using System;
using System.IO;

namespace Library.Helpers
{
    public static class FileHelper
    {
        public static void Save(int Sprint)
        {
            string read = "";
            if (File.Exists("Tasks.txt"))
            {
                read = File.ReadAllText("Tasks.txt");
                foreach (var a in TaskRepository.Tasks)
                {
                    a.Sprint = Sprint;
                    read += $"{a.Sprint} {a.Name} {a.Priority} {a.Complexity} {a.Type} {a.Status}\n";
                }
                File.WriteAllText("Tasks.txt", read);
                Console.WriteLine("Tasks save!");
            }
            else
            {
                foreach (var a in TaskRepository.Tasks)
                {
                    read += $"{a.Sprint} {a.Name} {a.Priority} {a.Complexity} {a.Type} {a.Status}\n";
                }
                File.WriteAllText("Tasks.txt", read);
                Console.WriteLine("Tasks save!");
            }
        }

        public static string[] Read()
        {
            return File.ReadAllLines("Tasks.txt");
        }
    }
}
