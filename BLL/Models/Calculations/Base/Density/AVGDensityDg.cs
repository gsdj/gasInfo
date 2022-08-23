using BLL.Constants;
using BLL.Interfaces.BaseCalculations;
using BLL.Interfaces.BaseCalculations.Density;
using BLL.Models.BaseModels.Components;
using DA.Entities;

namespace BLL.Calculations.Base.Density
{
   public class AVGDensityDg : IDensity<CharacteristicsDgAll>
   {
      private IAvgComponents<CharacteristicsDgAll, GasComponents> AvgC;
      public AVGDensityDg(IAvgComponents<CharacteristicsDgAll, GasComponents> avgC)
      {
         AvgC = avgC;
      }
      /// <summary>
      /// Средня плотность доменного газа
      /// </summary>
      /// <param name="obj"></param>
      /// <returns></returns>
      public decimal Calc(CharacteristicsDgAll obj)
      {
         var C = AvgC.Calc(obj);

         //return 0.01m * (C.H2 * 0.0837m + C.CO * 1.165m + C.CO2 * 1.842m + C.N2 * 1.166m + (100 - C.H2 - C.CO - C.CO2 - C.N2) * 0.0837m);
         return 0.01m * (C.H2 * PGasComponents.H2 + C.CO * PGasComponents.CO + C.CO2 * PGasComponents.CO2 + C.N2 * PGasComponents.N2 + (100 - C.H2 - C.CO - C.CO2 - C.N2) * PGasComponents.H2);
      }
   }
}
