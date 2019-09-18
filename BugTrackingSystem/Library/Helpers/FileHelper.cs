using Library.Tasks;
using System;
using System.IO;

namespace Library.Helpers
{
    public static class FileHelper
    {
        /// <summary>
        /// Save info about sprint in file
        /// </summary>
        /// <param name="Sprint"></param>
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
                Sprint++;
                FileWrite(read, Sprint);
            }
        }

        /// <summary>
        /// Write file
        /// </summary>
        /// <param name="read">info about sprint adding earlier</param>
        /// <param name="Sprint">number of sprint</param>
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

        /// <summary>
        /// Reading info about sprint from file
        /// </summary>
        /// <returns></returns>
        public static string[] Read()
        {
            return File.ReadAllLines("Tasks.txt");
        }
    }
}
