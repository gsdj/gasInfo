using Business.BusinessModels.BaseCalculations.Qn;
using Business.BusinessModels.Calculations.ConsGasQn;
using Business.BusinessModels.DataForCalculations;
using Business.DTO;
using Business.DTO.Consumption;
using Business.DTO.QcRc;
using Business.Interfaces.BaseCalculations.Consumption;
using Business.Interfaces.Calculations;
using Business.Interfaces.Calculations.ConsGasQn;
using System.Collections.Generic;
using System.Linq;

namespace Business.BusinessModels.Calculations
{
   public class CalcConsumptionKg : ICalculation<ConsumptionKgDTO>, ICalculations<ConsumptionKgDTO>
   {
      private ICalculation<DensityDTO> WetGas;
      //private IConsGasQn<ConsGasQn4000> ConsGasQn;
      //private ICalcQcRc<QcRcKc2> QcRcKc2;
      //private ICalcQcRc<QcRcCpsPpk> QcRcCpsPpk;
      private ICalcConsGasQnKc2 Kc2Qn;
      private ICalcConsGasQnCpsPpk CpsPpkQn;
      public CalcConsumptionKg(ICalculation<DensityDTO> wetGas, ICalcConsGasQnKc2 kc2Qn, ICalcConsGasQnCpsPpk cpsppkQn, IConsGasQn<ConsGasQn4000> gasQn, ICalcQcRc<QcRcKc2> qcrcKc2, ICalcQcRc<QcRcCpsPpk> qcrcCpsPpk)
      {
         WetGas = wetGas;
         //QcRcKc2 = qcrcKc2;
         //QcRcCpsPpk = qcrcCpsPpk;
         //ConsGasQn = gasQn;
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
         var charDg = data.CharacteristicsDg;
         var charKg = data.CharacteristicsKg;
         var pressure = data.Pressure;

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
         var qcrcGsuf = QcRc.Calc(kip.Gsuf45.Consumption, wetGas.Gsuf, kip.Gsuf45.Temperature, charKg.Kc1.Characteristics.Density),
         //--------

         return new ConsumptionKgDTO
         {
            Date = wetGas.Date,
            QcRcCb = qcrcKc2,
            QcRcCpsPpk = qcrcCpsPpk,
            QcRcGsuf = qcrcCpsPpk.Gsuf,
            ConsumptionCb = consCb,
            ConsumptionKc2Sum = consCb.Cb1 + consCb.Cb2 + consCb.Cb3 + consCb.Cb4,
            PkoQcRcSum = qcrcCpsPpk.Pko.Total, // qcrcCpsPpk.Pko.Value + qcrcCpsPpk.Uvtp,
            ConsumptionCpsPpk = consCpsPpk,
            ConsumptionCpsPpkSum = ConsGasQn.Calc(qcrcCpsPpk.Pko.Value + qcrcCpsPpk.Uvtp, charKg.Kc1.Characteristics.Qn) + ConsGasQn.Calc(qcrcCpsPpk.Spo, charKg.Kc1.Characteristics.Qn),
            ConsumptionMkSum = consCb.Cb5 + consCb.Cb6 + consCb.Cb7 + consCb.Cb8 + consCpsPpk.Pko + consCpsPpk.Spo,
            ConsumptionGsuf = ConsGasQn.Calc(qcrcCpsPpk.Gsuf, charKg.Kc1.Characteristics.Qn),
            ConsumptionMkGsufSum = consCb.Cb5 + consCb.Cb6 + consCb.Cb7 + consCb.Cb8 + consCpsPpk.Pko + consCpsPpk.Spo +
                                    ConsGasQn.Calc(qcrcCpsPpk.Gsuf, charKg.Kc1.Characteristics.Qn),
         };
      }
   }
}
