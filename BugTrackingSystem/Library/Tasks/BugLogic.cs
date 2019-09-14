using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Tasks
{
    public class BugLogic
    {
        public static Bug[] GetBug
        {
            get => Bug._bugList.ToArray();
        }

        public static void AddBug(Bug _bug)
        {
            Bug._bugList.Add(_bug);
        }

        public static void DelItemBug(int index)
        {
            Bug._bugList.RemoveAt(index);
        }
    }
}
