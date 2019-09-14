using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Tasks
{
    public class TechnicalDebt : BaseTask
    {
        public Guid Id { get; set; }
        public string NameTechDebt;
        //public int PriorityTechDebt;
        //public int ComplexityTechDebt;

        public static List<TechnicalDebt> _technicalDebtList;

        static  TechnicalDebt()
        {
            _technicalDebtList = new List<TechnicalDebt>();
        }

        public TechnicalDebt(string Name, int Priority, int Complexity) :base(Name, Priority, Complexity)
        {
            this.Id = Guid.NewGuid();
            this.NameTechDebt = Name;
            //this.PriorityTechDebt = Priority;
            //this.ComplexityTechDebt = Complexity;
        }
    }
}
