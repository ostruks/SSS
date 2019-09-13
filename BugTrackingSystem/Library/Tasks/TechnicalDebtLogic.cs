using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Tasks
{
    public class TechnicalDebtLogic
    {
        public static TechnicalDebt[] GetTechnicalDebts
        {
            get => TechnicalDebt._technicalDebtList.ToArray();
        }

        public static void AddTechnicalDebt(TechnicalDebt _technicalDebt)
        {
            TechnicalDebt._technicalDebtList.Add(_technicalDebt);
        }

        public static void DelItemTechnicalDebt(int index)
        {
            TechnicalDebt._technicalDebtList.RemoveAt(index);
        }
    }
}
