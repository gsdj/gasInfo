using BLL.Interfaces.BaseCalculations.Consumption;
using System;

namespace BLL.Calculations.Base.Consumption
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
