using BLL.Constants;
using BLL.Interfaces.BaseCalculations;
using DA.Entities.Characteristics;

namespace BLL.Calculations.Base.Qn
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
         //return (0.01m * (dg.H2 * 2400 + dg.CO * 2810));
         return (0.01m * (dg.H2 * QGasComponents.H2 + dg.CO * QGasComponents.CO));
      }
   }
}
