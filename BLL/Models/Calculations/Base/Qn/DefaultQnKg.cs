using BLL.Constants;
using BLL.Interfaces.BaseCalculations;
using DA.Entities.Characteristics;

namespace BLL.Calculations.Base.Qn
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
         //return (0.01m * (kg.CO * 2810 + kg.CnHm * 14540 + kg.CH4 * 7970 + kg.H2 * 2400));
         return (0.01m * (kg.CO * QGasComponents.CO + kg.CnHm * QGasComponents.CnHm + kg.CH4 * QGasComponents.CH4 + kg.H2 * QGasComponents.H2));
      }
   }
}
