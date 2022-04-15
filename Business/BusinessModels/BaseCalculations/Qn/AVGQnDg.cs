using Business.DTO.Characteristics.CharacteristicsGas;
using Business.Interfaces.BaseCalculations;
using DataAccess.Entities;

namespace Business.BusinessModels.BaseCalculations.Qn
{
   public class AVGQnDg : IQn<CharacteristicsDgAll>
   {
      private IAvgComponents<CharacteristicsDgAll, GasComponents> AvgC;
      public AVGQnDg(IAvgComponents<CharacteristicsDgAll, GasComponents> avgC)
      {
         AvgC = avgC;
      }
      /// <summary>
      /// Средняя калорийность доменного газа
      /// </summary>
      /// <param name="obj"></param>
      /// <returns></returns>
      public decimal Calc(CharacteristicsDgAll obj)
      {
         var C = AvgC.Calc(obj);
         return (C.H2 * 2400 + C.CO * 2810 + ((100 - C.H2 - C.CO - C.CO2 - C.N2) * 7970)) * 0.01m;
      }
   }
}
