using BLL.Interfaces.BaseCalculations;
using BLL.Interfaces.BaseCalculations.Consumption;
using System;

namespace BLL.Calculations.Base.Consumption
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
