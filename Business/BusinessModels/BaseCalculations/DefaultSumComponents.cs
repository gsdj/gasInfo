using Business.Interfaces.BaseCalculations;
namespace Business.BusinessModels.BaseCalculations
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
