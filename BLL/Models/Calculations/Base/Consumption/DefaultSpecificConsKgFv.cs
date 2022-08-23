using BLL.Constants;
using BLL.Interfaces.BaseCalculations.Consumption;
using System;

namespace BLL.Calculations.Base.Consumption
{
   public class DefaultSpecificConsKgFv : ISpecificConsKgFv
   {
      public decimal Calc(decimal consKg, decimal consKgFv)
      {
         if (consKg == 0 || consKgFv == 0)
            return 0;

         return Math.Round((consKg / consKgFv * GasConstants.ConsFvC), 10);
      }
   }
}
