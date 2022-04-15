using Business.Interfaces.BaseCalculations;
using DataAccess.Entities.Characteristics;

namespace Business.BusinessModels.BaseCalculations.Qn
{
   public class DefaultQnDg : IQn<DG>
   {
      /// <summary>
      /// Калорийность доменного газа
      /// </summary>
      /// <param name="dg"></param>
      /// <returns></returns>
      public decimal Calc(DG dg)
      {
         return (0.01m * (dg.H2 * 2400 + dg.CO * 2810));
      }
   }
}
