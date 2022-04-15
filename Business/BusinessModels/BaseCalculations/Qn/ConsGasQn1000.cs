using Business.Interfaces.BaseCalculations;
using System;

namespace Business.BusinessModels.BaseCalculations.Qn
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
