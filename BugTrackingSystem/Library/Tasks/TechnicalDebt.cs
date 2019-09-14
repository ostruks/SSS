using System;
using System.Collections.Generic;

namespace Library.Tasks
{
    public class TechnicalDebt : BaseTask
    {
        public static List<TechnicalDebt> _technicalDebtList;

        static  TechnicalDebt()
        {
            _technicalDebtList = new List<TechnicalDebt>();
        }

        public TechnicalDebt(string Name, int Priority, int Complexity) :base(Name, Priority, Complexity)
        {
            Id = Guid.NewGuid();
        }
    }
}
