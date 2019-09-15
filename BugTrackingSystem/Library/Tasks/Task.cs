using System;

namespace Library.Tasks
{
    public class Task : BaseTask
    {
        public Task(string Name, int Priority, int Complexity, string Status) : base(Name, Priority, Complexity, Status)
        {
            Id = Guid.NewGuid();
        }
    }
}
