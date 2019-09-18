using System;

namespace Library.Tasks
{
    public class TechnicalDebt : BaseTask
    {
        public override string Type
        {
            get
            {
                return "TechnicalDebt";
            }
        }

        public TechnicalDebt(string Name, int Priority, int Complexity, string Status) : base(Name, Priority, Complexity, Status)
        {
        }

        public override string Display()
        {
            return $"TaskTechnicalDebt {Name}, priority: {Priority}, complexity: {Complexity}, duration: {Duration}, status: {Status}";
        }
    }
}
