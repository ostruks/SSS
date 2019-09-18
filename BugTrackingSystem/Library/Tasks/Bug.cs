using System;

namespace Library.Tasks
{
    public class Bug : BaseTask
    {
        public override string Type
        {
            get
            {
                return "Bug";
            }
        }

        public Bug(string Name, int Priority, int Complexity, string Status) : base(Name, Priority, Complexity, Status)
        {
        }

        public override string Display()
        {
            return $"Bug: {Name}, priority: {Priority}, complexity: {Complexity}, duration: {Duration}, status: {Status}";
        }
    }
}
