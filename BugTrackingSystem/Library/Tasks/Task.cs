using System;

namespace Library.Tasks
{
    public class Task : BaseTask
    {
        public Task(string Name, int Priority, int Complexity) : base(Name, Priority, Complexity)
        {
            Id = Guid.NewGuid();
        }
    }
}
