using Business.BusinessModels.Constants;
using Business.Interfaces.BaseCalculations.Consumption;
using System;

namespace Business.BusinessModels.BaseCalculations.Consumption
{
   public class DefaultConsPg : IConsPg
   {
      public decimal Calc(decimal cons, decimal PPa, decimal pressure, decimal temp)
      {
         if (cons == 0 || pressure == 0)
            return 0;

         decimal result = cons * GasConstants.Tc * (PPa + pressure * GasConstants.PexcC) / ((GasConstants.TpC + temp) * GasConstants.Pc * 1);
         return Math.Round(result, 10);
      }
   }
}
