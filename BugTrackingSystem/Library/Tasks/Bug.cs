using System;

namespace Library.Tasks
{
    public class Bug : BaseTask
    {
        public Bug(string Name, int Priority, int Complexity, string Status) : base(Name, Priority, Complexity, Status)
        {
            Id = Guid.NewGuid();
        }

        public override string Display()
        {
            return $"Bug: {Name}, priority: {Priority}, complexity: {Complexity}, duration: {Duration}, status: {Status}";
        }
    }
}
