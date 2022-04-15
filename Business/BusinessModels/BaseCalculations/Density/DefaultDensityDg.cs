using Business.Interfaces.BaseCalculations.Density;
using DataAccess.Entities.Characteristics;

namespace Business.BusinessModels.BaseCalculations.Density
{
   public class DefaultDensityDg : IDensity<DG>
   {
      /// <summary>
      /// Плотность доменного газа
      /// </summary>
      /// <param name="dg"></param>
      /// <returns></returns>
      public decimal Calc(DG dg)
      {
         return (0.01m * (dg.H2 * 0.0837m + dg.CO * 1.165m + dg.CO2 * 1.842m + dg.N2 * 1.166m));
      }
   }
}
