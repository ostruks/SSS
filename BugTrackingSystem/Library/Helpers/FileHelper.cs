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
                FileWrite(read, Sprint);
            }
            else
            {
                FileWrite(read);
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

        public static string[] Read()
        {
            return File.ReadAllLines("Tasks.txt");
        }
    }
}
