using Library.Tasks;
using System;
using System.IO;

namespace Library.Helpers
{
    public static class FileHelper
    {
        public static void Save()
        {
            if (File.Exists("Tasks.txt"))
            {
                string read = File.ReadAllText("Tasks.txt");
                foreach (var a in TaskRepository.Tasks)
                {
                    read += a + "\n";
                }
                File.WriteAllText("Tasks.txt", read);
            }
            else
            {
                Console.WriteLine("File is not exist!");
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
