using System;

namespace Library.Tasks
{
    public class TechnicalDebt : BaseTask
    {
        public TechnicalDebt(string Name, int Priority, int Complexity) :base(Name, Priority, Complexity)
        {
            Id = Guid.NewGuid();
        }
    }
}
