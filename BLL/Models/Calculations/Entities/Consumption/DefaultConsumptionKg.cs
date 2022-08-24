using BLL.DataHelpers;
using BLL.DTO;
using BLL.DTO.Consumption;
using BLL.Interfaces.Calculations;
using BLL.Interfaces.Calculations.ConsGasQn;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Calculations.Entities.Consumption
{
   public class DefaultConsumptionKg : ICalculation<ConsumptionKgDTO>, ICalculations<ConsumptionKgDTO>
   {
      private ICalculation<DensityDTO> WetGas;
      private ICalcConsGasQnKc2 Kc2Qn;
      private ICalcConsGasQnCpsPpk CpsPpkQn;
      public DefaultConsumptionKg(ICalculation<DensityDTO> wetGas, ICalcConsGasQnKc2 kc2Qn, ICalcConsGasQnCpsPpk cpsppkQn)
      {
         WetGas = wetGas;
         Kc2Qn = kc2Qn;
         CpsPpkQn = cpsppkQn;
      }

      public IEnumerable<ConsumptionKgDTO> CalcEntities(EnumerableData data)
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

         List<ConsumptionKgDTO> conskgDTO = new List<ConsumptionKgDTO>(d.Count());
         foreach (var item in d)
         {
            conskgDTO.Add(CalcEntity(item));
         }
         return conskgDTO;
      }

      public ConsumptionKgDTO CalcEntity(Data data)
      {
         var kip = data.Kip;
         var charKg = data.CharacteristicsKg;

         var wetGas = WetGas.CalcEntity(data);

         var QcRcKgData = new QcRcKgData
         {
            CharacteristicsKg = data.CharacteristicsKg,
            Kip = data.Kip,
            WetGas = wetGas,
         };

         var qcrcKc2 = Kc2Qn.CalcQcRcKc2.Calc(QcRcKgData);
         var consCb = Kc2Qn.Calc(qcrcKc2, charKg);

         var qcrcCpsPpk = CpsPpkQn.CalcQcRcCpsPpk.Calc(QcRcKgData);
         var consCpsPpk = CpsPpkQn.Calc(qcrcCpsPpk, charKg);
         var qcrcGsuf = Kc2Qn.CalcQcRcKc2.QcRc.Calc(kip.Gsuf45.Consumption.Value, wetGas.Gsuf, kip.Gsuf45.Temperature, charKg.Kc1.Density);

         var consGsuf = CpsPpkQn.ConsGasQn.Calc(qcrcGsuf, charKg.Kc1.Qn);
         var consCpsPpkSum = consCpsPpk.Pko.Total + consCpsPpk.Spo;

         return new ConsumptionKgDTO
         {
            Date = wetGas.Date,
            QcRcCb = qcrcKc2,
            QcRcCpsPpk = qcrcCpsPpk,
            QcRcGsuf = qcrcGsuf,
            ConsumptionCb = consCb,
            ConsumptionKc2Sum = consCb.Sum,
            PkoQcRcSum = qcrcCpsPpk.Pko.Total, // qcrcCpsPpk.Pko.Value + qcrcCpsPpk.Uvtp,
            ConsumptionCpsPpk = consCpsPpk,
            ConsumptionCpsPpkSum = consCpsPpkSum,
            ConsumptionMkSum = consCb.Sum + consCpsPpkSum,
            ConsumptionGsuf = consGsuf,
            ConsumptionMkGsufSum = consCb.Sum + consCpsPpkSum + consGsuf,
         };
      }
   }
}
