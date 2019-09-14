using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Tasks
{
    public class Bug : BaseTask
    {
        public static List<Bug> _bugList;

        static Bug()
        {
            _bugList = new List<Bug>();
        }

        public Bug(string Name, int Priority, int Complexity) : base(Name, Priority, Complexity)
        {
            Id = Guid.NewGuid();
        }
    }
}
