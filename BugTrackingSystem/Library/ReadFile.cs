using Library.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class ReadFile : IReadFile
    {
        public string[] Read()
        {
            return File.ReadAllLines("Tasks.txt");
        }
    }
}
