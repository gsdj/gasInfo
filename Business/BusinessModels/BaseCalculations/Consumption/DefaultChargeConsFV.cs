using Business.Interfaces.BaseCalculations;
using Business.Interfaces.BaseCalculations.Consumption;
using System;

namespace Business.BusinessModels.BaseCalculations.Consumption
{
   public class DefaultChargeConsFV : IChargeConsFV<DefaultChargeConsFV>
   {
      private IDryCokeProduction<DefaultDryCokeProduction> DryCoke;
      public DefaultChargeConsFV(IDryCokeProduction<DefaultDryCokeProduction> dryCoke)
      {
         DryCoke = dryCoke;
      }
      public decimal Calc(int Cb, decimal CbCoef, decimal FvCoef)
      {
         return Math.Round(DryCoke.Calc(Cb, CbCoef) * FvCoef, 10);
      }
   }
}
