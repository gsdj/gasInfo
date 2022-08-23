using BLL.Interfaces.BaseCalculations.Consumption;
using System;

namespace BLL.Calculations.Base.Qn
{
   public class ConsGasQn4000 : IConsGasQn<ConsGasQn4000>
   {
      public decimal Calc(decimal qcrc, decimal qn)
      {
         if (qcrc == 0 || qn == 0)
            return 0;

         return Math.Round((qcrc * qn / 4000), 10);
      }
   }
}
