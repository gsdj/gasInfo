using BLL.Interfaces.BaseCalculations.Consumption;
using System;

namespace BLL.Calculations.Base.Qn
{
   public class ConsGasQn1000 : IConsGasQn<ConsGasQn1000>
   {
      public decimal Calc(decimal qcrc, decimal qn)
      {
         if (qcrc == 0 || qn == 0)
            return 0;

         return Math.Round((qcrc * qn / 1000), 10);
      }
   }
}
