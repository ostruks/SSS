using System;

namespace Library.Tasks
{
    public class Bug : BaseTask
    {
        public Bug(string Name, int Priority, int Complexity) : base(Name, Priority, Complexity)
        {
            Id = Guid.NewGuid();
        }
    }
}
