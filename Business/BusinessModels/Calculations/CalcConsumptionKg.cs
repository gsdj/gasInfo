using Business.BusinessModels.BaseCalculations;
using Business.BusinessModels.DataForCalculations;
using Business.DTO;
using Business.DTO.Consumption;
using Business.DTO.QcRc;
using Business.Interfaces.BaseCalculations;
using Business.Interfaces.Calculations;
using System.Collections.Generic;
using System.Linq;

namespace Business.BusinessModels.Calculations
{
   public class CalcConsumptionKg : ICalculation<ConsumptionKgDTO>, ICalculations<ConsumptionKgDTO>
   {
      private ICalculation<DensityDTO> WetGas;
      private IQcRc QcRc;
      private IConsGasQn<ConsGasQn4000> ConsGasQn;
      public CalcConsumptionKg(ICalculation<DensityDTO> wetGas, IQcRc qcrc, IConsGasQn<ConsGasQn4000> gasQn)
      {
         WetGas = wetGas;
         QcRc = qcrc;
         ConsGasQn = gasQn;
      }

      public IEnumerable<ConsumptionKgDTO> CalcEntities(EnumerableData data)
      {
         var Data = data as ConsumptionKgEnumData;
         var charDg = Data.CharacteristicsDg;
         var charKg = Data.CharacteristicsKg;
         var kip = Data.Kip;
         var pressure = Data.Pressure;
         
         var d =
            from t1charDg in charDg
            join t2kip in kip on new { t1charDg.Date } equals new { t2kip.Date }
            join t3charKg in charKg on new { t2kip.Date } equals new { t3charKg.Date }
            join t4pressure in pressure on new { t3charKg.Date } equals new { t4pressure.Date }
            select new ConsumptionKgData
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
         ConsumptionKgData Data = data as ConsumptionKgData;
         var kip = Data.Kip;
         var charDg = Data.CharacteristicsDg;
         var charKg = Data.CharacteristicsKg;
         var pressure = Data.Pressure;

         var wetGas = WetGas.CalcEntity(data);

         var qcrcAll = new
         {
            QcRcCb = new QcRcKc2
            {
               Cb5 = QcRc.Calc(kip.Cb5.Consumption, wetGas.Cb5, kip.Cb5.TempBeforeHeating, charKg.Kc1.Characteristics.Density, true),
               Cb6 = QcRc.Calc(kip.Cb6.Consumption, wetGas.Cb6, kip.Cb6.TempBeforeHeating, charKg.Kc1.Characteristics.Density, true),
               Cb7 =
               {
                  Ms = QcRc.Calc(kip.Cb7.ConsumptionMs, wetGas.Cb7, kip.Cb7.TempBeforeHeating, charKg.Kc2.Characteristics.Density),
                  Ks = QcRc.Calc(kip.Cb7.ConsumptionKs, wetGas.Cb7, kip.Cb7.TempBeforeHeating, charKg.Kc2.Characteristics.Density),
               },
               Cb8 =
               {
                  Ms = QcRc.Calc(kip.Cb8.ConsumptionMs, wetGas.Cb8, kip.Cb8.TempBeforeHeating, charKg.Kc2.Characteristics.Density),
                  Ks = QcRc.Calc(kip.Cb8.ConsumptionKs, wetGas.Cb8, kip.Cb8.TempBeforeHeating, charKg.Kc2.Characteristics.Density),
               },
            },
            QcRcCpsPpk = new QcRcCpsPpk
            {
               Pko =
               {
                  Ms = QcRc.Calc(kip.Pkc.ConsumptionMs, wetGas.Pkc, kip.Pkc.Temperature, charKg.Kc1.Characteristics.Density),
                  Ks = QcRc.Calc(kip.Pkc.ConsumptionKs, wetGas.Pkc, kip.Pkc.Temperature, charKg.Kc1.Characteristics.Density),
               },
               Uvtp = QcRc.Calc(kip.Uvtp.Consumption, wetGas.Uvtp, kip.Uvtp.Temperature, charKg.Kc1.Characteristics.Density),
               Spo = QcRc.Calc(kip.Spo.Consumption, wetGas.Spo, kip.Spo.Temperature, charKg.Kc1.Characteristics.Density),
            },
            QcRcGsuf = QcRc.Calc(kip.Gsuf45.Consumption, wetGas.Gsuf, kip.Gsuf45.Temperature, charKg.Kc1.Characteristics.Density),
         };

         var consCb = new ConsumptionKc2<decimal>
         {
            Cb5 = ConsGasQn.Calc(qcrcAll.QcRcCb.Cb5, charKg.Kc1.Characteristics.Qn),
            Cb6 = ConsGasQn.Calc(qcrcAll.QcRcCb.Cb6, charKg.Kc1.Characteristics.Qn),
            Cb7 = ConsGasQn.Calc(qcrcAll.QcRcCb.Cb7.Value, charKg.Kc2.Characteristics.Qn),
            Cb8 = ConsGasQn.Calc(qcrcAll.QcRcCb.Cb8.Value, charKg.Kc2.Characteristics.Qn),
         };

         var consCpsPpk = new ConsumptionCpsPpk
         {
            Pko = ConsGasQn.Calc(qcrcAll.QcRcCpsPpk.Pko.Value + qcrcAll.QcRcCpsPpk.Uvtp, charKg.Kc1.Characteristics.Qn),
            Spo = ConsGasQn.Calc(qcrcAll.QcRcCpsPpk.Spo, charKg.Kc1.Characteristics.Qn),
         };

         return new ConsumptionKgDTO
         {
            Date = wetGas.Date,
            QcRcCb = qcrcAll.QcRcCb,
            QcRcCpsPpk = qcrcAll.QcRcCpsPpk,
            QcRcGsuf = qcrcAll.QcRcGsuf,
            ConsumptionCb = consCb,
            ConsumptionKc2Sum = consCb.Cb5 + consCb.Cb6 + consCb.Cb7 + consCb.Cb8,
            PkoSum = qcrcAll.QcRcCpsPpk.Pko.Value + qcrcAll.QcRcCpsPpk.Uvtp,
            ConsumptionCpsPpk = consCpsPpk,
            ConsumptionCpsPpkSum = ConsGasQn.Calc(qcrcAll.QcRcCpsPpk.Pko.Value + qcrcAll.QcRcCpsPpk.Uvtp, charKg.Kc1.Characteristics.Qn) + ConsGasQn.Calc(qcrcAll.QcRcCpsPpk.Spo, charKg.Kc1.Characteristics.Qn),
            ConsumptionMkSum = consCb.Cb5 + consCb.Cb6 + consCb.Cb7 + consCb.Cb8 + consCpsPpk.Pko + consCpsPpk.Spo,
            ConsumptionGsuf = ConsGasQn.Calc(qcrcAll.QcRcGsuf, charKg.Kc1.Characteristics.Qn),
            ConsumptionMkGsufSum = consCb.Cb5 + consCb.Cb6 + consCb.Cb7 + consCb.Cb8 + consCpsPpk.Pko + consCpsPpk.Spo +
                                    ConsGasQn.Calc(qcrcAll.QcRcGsuf, charKg.Kc1.Characteristics.Qn),
         };
      }
   }
}
