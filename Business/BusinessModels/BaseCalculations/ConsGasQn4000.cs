using Business.Interfaces.BaseCalculations;
using System;

namespace Business.BusinessModels.BaseCalculations
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
