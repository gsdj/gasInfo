using Business.BusinessModels.DataForCalculations;
using Business.DTO;
using Business.Interfaces.Calculations;
using Business.Interfaces.Calculations.ConsGasQn;
using System.Collections.Generic;
using System.Linq;

namespace Business.BusinessModels.Calculations
{
   public class CalcConsumptionKg : ICalculation<ConsumptionKgDTO>, ICalculations<ConsumptionKgDTO>
   {
      private ICalculation<DensityDTO> WetGas;
      private ICalcConsGasQnKc2 Kc2Qn;
      private ICalcConsGasQnCpsPpk CpsPpkQn;
      public CalcConsumptionKg(ICalculation<DensityDTO> wetGas, ICalcConsGasQnKc2 kc2Qn, ICalcConsGasQnCpsPpk cpsppkQn)
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

         //---v2---
         var qcrcKc2 = Kc2Qn.CalcQcRcKc2.Calc(QcRcKgData);
         var consCb = Kc2Qn.Calc(qcrcKc2, charKg);

         var qcrcCpsPpk = CpsPpkQn.CalcQcRcCpsPpk.Calc(QcRcKgData);
         var consCpsPpk = CpsPpkQn.Calc(qcrcCpsPpk, charKg);
         var qcrcGsuf = CpsPpkQn.CalcQcRcCpsPpk.QcRc.Calc(kip.Gsuf45.Consumption.Value, wetGas.Gsuf, kip.Gsuf45.Temperature, charKg.Kc1.Characteristics.Density);

         var consGsuf = CpsPpkQn.ConsGasQn.Calc(qcrcGsuf, charKg.Kc1.Characteristics.Qn);
         var consKc2Sum = consCb.Cb1 + consCb.Cb2 + consCb.Cb3 + consCb.Cb4;
         var consCpsPpkSum = consCpsPpk.Pko.Pkp + consCpsPpk.Pko.Uvtp + consCpsPpk.Spo;
         //--------

         return new ConsumptionKgDTO
         {
            Date = wetGas.Date,
            QcRcCb = qcrcKc2,
            QcRcCpsPpk = qcrcCpsPpk,
            QcRcGsuf = qcrcGsuf,
            ConsumptionCb = consCb,
            ConsumptionKc2Sum = consKc2Sum,
            PkoQcRcSum = qcrcCpsPpk.Pko.Total, // qcrcCpsPpk.Pko.Value + qcrcCpsPpk.Uvtp,
            ConsumptionCpsPpk = consCpsPpk,
            ConsumptionCpsPpkSum = consCpsPpkSum,
            ConsumptionMkSum = consKc2Sum + consCpsPpkSum,
            ConsumptionGsuf = consGsuf,
            ConsumptionMkGsufSum = consKc2Sum + consCpsPpkSum + consGsuf,
         };
      }
   }
}
