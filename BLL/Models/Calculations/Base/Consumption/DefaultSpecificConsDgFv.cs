using BLL.Constants;
using BLL.Interfaces.BaseCalculations.Consumption;
using System;

namespace BLL.Calculations.Base.Consumption
{
   public class DefaultSpecificConsDgFv : ISpecificConsDgFv
   {
      public decimal Calc(decimal consDg, decimal consPg, decimal consFv)
      {
         if (consDg == 0 && consPg == 0 || consFv == 0)
            return 0;

         decimal result = ((consDg * GasConstants.UdDgC) + (consPg * GasConstants.UdPgC)) / consFv;
         return Math.Round(result, 10);
      }
   }
}
