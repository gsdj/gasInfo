using Business.Interfaces.BaseCalculations;
using DataAccess.Entities.Characteristics;

namespace Business.BusinessModels.BaseCalculations
{
   public class DefaultQnKg : IQn<KG>
   {
      /// <summary>
      /// Калорийность коксового газа
      /// </summary>
      /// <param name="kg"></param>
      /// <returns></returns>
      public decimal Calc(KG kg)
      {
         return (0.01m * (kg.CO * 2810 + kg.CnHm * 14540 + kg.CH4 * 7970 + kg.H2 * 2400));
      }
   }
}
