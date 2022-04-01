using Business.Interfaces.BaseCalculations;
using DataAccess.Entities.Characteristics;

namespace Business.BusinessModels.BaseCalculations
{
   public class DefaultDensityKg : IDensity<KG>
   {
      //private ConfigurationSettings
      /// <summary>
      /// Плотность коксового газа
      /// </summary>
      /// <param name="kg"></param>
      /// <returns></returns>
      public decimal Calc(KG kg)
      {
         return (0.01m * (kg.CO2 * 1.842m + kg.O2 * 1.331m + kg.CO * 1.165m + kg.CnHm * 1.228m + kg.CH4 * 0.6679m + kg.H2 * 0.0837m + kg.N2 * 1.166m));
      }
   }
}
