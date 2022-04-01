using Business.Interfaces.BaseCalculations;
using System;

namespace Business.BusinessModels.BaseCalculations
{
   public class DefaultConsPgCb : IConsPgCb
   {
      public decimal Calc(decimal consDg, decimal consPgKc, decimal kcSum)
      {
         if (consDg == 0 || consPgKc == 0 || kcSum == 0)
            return 0;

         decimal result = consPgKc * (consDg / kcSum);
         return Math.Round(result, 10);
      }
   }
}
