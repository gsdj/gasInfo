using Business.Interfaces.BaseCalculations;
using System;

namespace Business.BusinessModels.BaseCalculations
{
   public class DefaultSpoPerKus : ISpoPerKus<DefaultSpoPerKus>
   {
      public decimal Calc(decimal Pkp, decimal coefPkp, decimal CoefPeka)
      {
         return Math.Round(((Pkp * coefPkp) * GasConstants.SpoC) / (CoefPeka / 100), 10);
      }
   }
}
