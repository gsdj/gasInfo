using BLL.Constants;
using BLL.Interfaces.BaseCalculations;

namespace BLL.Calculations.Base
{
   public class DefaultDryCokeProduction : IDryCokeProduction<DefaultDryCokeProduction>
   {
      public decimal Calc(int cbAmmount, decimal cbCoef)
      {
         return cbAmmount * cbCoef * GasConstants.Kb18C;
      }
   }
}
