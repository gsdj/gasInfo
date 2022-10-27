using BLL.DataHelpers;
using BLL.DTO;
using BLL.DTO.Consumption;
using BLL.Interfaces.Calculations;
using BLL.Interfaces.Calculations.ConsGasQn;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Calculations.Entities.Consumption
{
   public class DefaultConsumptionDg :/* ICalculation<ConsumptionDgDTO>, */ICalculations<ConsumptionDgDTO>
   {
      private ICalculation<DensityDTO> WetGas;
      private ICalcConsGasQnKc1 ConsGasQn;
      public DefaultConsumptionDg(ICalculations<DensityDTO> wetGas, ICalcConsGasQnKc1 consQn)
      {
         WetGas = wetGas;
         ConsGasQn = consQn;
      }
      public IEnumerable<ConsumptionDgDTO> CalcEntities(EnumerableData data)
      {
         var d =
            from t1charDg in data.CharacteristicsDg
            join t2kip in data.Kip on new { t1charDg.Date } equals new { t2kip.Date }
            join t3charKg in data.CharacteristicsKg on new { t2kip.Date } equals new { t3charKg.Date }
            join t4pressure in data.Pressure on new { t3charKg.Date } equals new { t4pressure.Date }
            select new Data
            {
               CharacteristicsDg = t1charDg,
               Kip = t2kip,
               CharacteristicsKg = t3charKg,
               Pressure = t4pressure,
            };

         List<ConsumptionDgDTO> consdgDTO = new List<ConsumptionDgDTO>(d.Count());

         foreach (var item in d)
         {
            consdgDTO.Add(CalcEntity(item));
         }
         return consdgDTO;
      }

      public ConsumptionDgDTO CalcEntity(Data data)
      {
         var charDg = data.CharacteristicsDg;

         var wetGas = WetGas.CalcEntity(data);

         var QcRcDgData = new QcRcDgData
         {
            CharacteristicsDg = data.CharacteristicsDg,
            Kip = data.Kip,
            WetGas = wetGas,
         };

         var qcrcKc1 = ConsGasQn.CalcQcRcKc1.Calc(QcRcDgData);
         var consKc1 = ConsGasQn.Calc(qcrcKc1, charDg);

         return new ConsumptionDgDTO
         {
            Date = charDg.Date,
            QcRc = qcrcKc1,
            ConsumptionDg = consKc1,
            ConsumptionDgMk = consKc1.Sum,
         };
      }
   }
}
