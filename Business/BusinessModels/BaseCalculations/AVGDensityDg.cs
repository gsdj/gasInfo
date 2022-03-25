using Business.DTO.Characteristics.CharacteristicsGas;
using Business.Interfaces.BaseCalculations;
using DataAccess.Entities;

namespace Business.BusinessModels.BaseCalculations
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
         //var C = new
         //{
         //   H2 = (obj.Kc1.H2 + obj.Kc2.H2) / 2,
         //   CO = (obj.Kc1.CO + obj.Kc2.CO) / 2,
         //   CO2 = (obj.Kc1.CO2 + obj.Kc2.CO2) / 2,
         //   N2 = (obj.Kc1.N2 + obj.Kc2.N2) / 2,
         //};

         return 0.01m * (C.H2 * 0.0837m + C.CO * 1.165m + C.CO2 * 1.842m + C.N2 * 1.166m + (100 - C.H2 - C.CO - C.CO2 - C.N2) * 0.0837m);
      }
   }
}
