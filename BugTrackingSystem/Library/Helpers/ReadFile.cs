using Library.Interfaces;
using System.IO;

namespace Library.Helpers
{
    public class ReadFile : IReadFile
    {
        /// <summary>
        /// Read info from file
        /// </summary>
        /// <returns>string array from file</returns>
        public string[] Read()
        {
            return File.ReadAllLines("Tasks.txt");
        }

        internal string Read(string path)
        {

            return File.ReadAllText(path);
        }
    }
}
