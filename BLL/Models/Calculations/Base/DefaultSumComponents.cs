using BLL.Interfaces.BaseCalculations;

namespace BLL.Calculations.Base
{
   public class DefaultSumComponents : ISumComponents
   {
      public decimal Calc(params decimal[] components)
      {
         decimal result = 0;
         foreach (var item in components)
         {
            result += item;
         }
         return result;
      }
   }
}
