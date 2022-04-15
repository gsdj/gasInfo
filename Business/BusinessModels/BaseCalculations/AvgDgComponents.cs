using Business.DTO.Characteristics.CharacteristicsGas;
using Business.Interfaces.BaseCalculations;
using DataAccess.Entities;

namespace Business.BusinessModels.BaseCalculations
{
   public class AvgDgComponents : IAvgComponents<CharacteristicsDgAll, GasComponents>
   {
      public GasComponents Calc(CharacteristicsDgAll obj)
      {
         return new GasComponents
         {
            H2 = obj.Kc1.H2 * 0.33m + obj.Kc2.H2 * (1 - 0.33m),
            CO = obj.Kc1.CO * 0.33m + obj.Kc2.CO * (1 - 0.33m),
            CO2 = obj.Kc1.CO2 * 0.33m + obj.Kc2.CO2 * (1 - 0.33m),
            N2 = obj.Kc1.N2 * 0.33m + obj.Kc2.N2 * (1 - 0.33m),
         };
      }
   }
}
