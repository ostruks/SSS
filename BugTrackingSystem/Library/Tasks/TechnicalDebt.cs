using System;

namespace Library.Tasks
{
    public class TechnicalDebt : BaseTask
    {
        public TechnicalDebt(string Name, int Priority, int Complexity, string Status) :base(Name, Priority, Complexity, Status)
        {
            Id = Guid.NewGuid();
        }

        public override string Display()
        {
            return $"TaskTechnicalDebt {Name}, priority: {Priority}, complexity: {Complexity}, duration: {Duration}, status: {Status}";
        }
    }
}
