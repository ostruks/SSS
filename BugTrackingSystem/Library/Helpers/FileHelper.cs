using Library.Tasks;
using System;
using System.IO;

namespace Library.Helpers
{
    public static class FileHelper
    {
        public static void Save()
        {
            string read = "";
            if (File.Exists("Tasks.txt"))
            {
                read = File.ReadAllText("Tasks.txt");
                read += "\n";
                foreach (var a in TaskRepository.Tasks)
                {
                    read += $"{a.Name} {a.Priority} {a.Complexity} {(a is Bug ? 1 : a is Task ? 2 : 3)} {a.Status}\n";
                }
                File.WriteAllText("Tasks.txt", read);
                Console.WriteLine("Tasks save!");
            }
            else
            {
                foreach (var a in TaskRepository.Tasks)
                {
                    read += $"{a.Name} {a.Priority} {a.Complexity} {(a is Bug ? 1 : a is Task ? 2 : 3)} {a.Status}\n";
                }
                File.WriteAllText("Tasks.txt", read);
                Console.WriteLine("Tasks save!");
            }
        }

        public static string[] Read()
        {
            if (File.Exists("Tasks.txt"))
            {
                return File.ReadAllLines("Tasks.txt");
            }
            else
            {
                Console.WriteLine("File is not exist!");
                return new string[0];
            }
        }
    }
}
