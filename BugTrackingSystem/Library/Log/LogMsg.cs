using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Log
{
    public static class LogMsg
    {
        /// <summary>
        /// Write Log
        /// </summary>
        /// <param name="msg">text exception</param>
        public static void WriteLog(string msg)
        {
            if (string.IsNullOrEmpty(msg)) return;
            string path = Directory.GetCurrentDirectory() + "\\ApplicationLog.Log";
            using (var outfile = new StreamWriter(path, true, Encoding.UTF8))
            {
                outfile.WriteLine("***********************");
                outfile.WriteLine($"Data: {DateTime.Now}");
                outfile.WriteLine();
                outfile.Write(msg);
            }
        }
    }
}
