using System;
using System.IO;
using Library;
using Library.Helpers;
using Library.Tasks;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            bool MQuit = false;
            int ChoiceNomMenu = 0;

            Controller.FirstLoad();
            Controller.ShowMenuInConsole();
            Controller.JobWithMenu(ref MQuit, ref ChoiceNomMenu);
        }


    }
}