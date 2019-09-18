using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Interfaces;
using Library.Tasks;

namespace Library
{
    public class SaveFile : ISaveFile
    {        
        public void Save(int Sprint)
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
    }
}
