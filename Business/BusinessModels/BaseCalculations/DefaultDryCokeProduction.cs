using Business.BusinessModels.Constants;
using Business.Interfaces.BaseCalculations;

namespace Business.BusinessModels.BaseCalculations
{
   public class DefaultDryCokeProduction : IDryCokeProduction<DefaultDryCokeProduction>
   {
      public decimal Calc(int cbAmmount, decimal cbCoef)
      {
         return cbAmmount * cbCoef * GasConstants.Kb18C;
      }
   }
}
