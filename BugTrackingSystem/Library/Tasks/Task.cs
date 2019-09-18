using System;

namespace Library.Tasks
{
    public class Task : BaseTask
    {
        public override string Type
        {
            get
            {
                return "Task";
            }
        }

        public Task(string Name, int Priority, int Complexity, string Status) : base(Name, Priority, Complexity, Status)
        {
        }

        public override string Display()
        {
            return $"Task: {Name}, priority: {Priority}, complexity: {Complexity}, duration: {Duration}, status: {Status}";
        }
    }
}
