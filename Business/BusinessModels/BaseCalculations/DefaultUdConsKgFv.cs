using Business.Interfaces.BaseCalculations;
using System;
namespace Business.BusinessModels.BaseCalculations
{
   public class DefaultUdConsKgFv : IUdConsKgFv
   {
      public decimal Calc(decimal consKg, decimal consKgFv)
      {
         if (consKg == 0 || consKgFv == 0)
            return 0;

         return Math.Round((consKg / consKgFv * GasConstants.ConsFvC), 10);
      }
   }
}
