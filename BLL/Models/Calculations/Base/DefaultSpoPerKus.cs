using BLL.Constants;
using BLL.Interfaces.BaseCalculations;
using System;

namespace BLL.Calculations.Base
{
   public class DefaultSpoPerKus : ISpoPerKus<DefaultSpoPerKus>
   {
      public decimal Calc(decimal Pkp, decimal coefPkp, decimal CoefPeka)
      {
         return Math.Round(((Pkp * coefPkp) * GasConstants.SpoC) / (CoefPeka / 100), 10);
      }
   }
}
