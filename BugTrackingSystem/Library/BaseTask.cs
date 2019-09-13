using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public abstract class BaseTask
    {
        protected string _name;
        protected int _priority;
        public int Complexity { get; set; }
        public BaseTask(string Name, int Priority)
        {
            _name = Name;
            _priority = Priority;
        }
    }
}
