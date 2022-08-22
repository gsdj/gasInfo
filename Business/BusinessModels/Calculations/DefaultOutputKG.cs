using Business.BusinessModels.BaseCalculations;
using Business.BusinessModels.BaseCalculations.Qn;
using Business.BusinessModels.DataForCalculations;
using Business.DTO;
using Business.Interfaces.BaseCalculations;
using Business.Interfaces.BaseCalculations.Consumption;
using Business.Interfaces.BaseCalculations.Production;
using Business.Interfaces.Calculations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.BusinessModels.Calculations
{
   public class DefaultOutputKG : ICalculation<OutputKgDTO>, ICalculations<OutputKgDTO>
   {
      private IQcRc QcRc;
      private IConsGasQn<ConsGasQn4000> ConsGasQn;
      private ICalculation<DensityDTO> WetGas;
      private ICokeCbConsumptionDryCalc CbDry;
      public DefaultOutputKG(ICalculation<DensityDTO> wetGas, IQcRc qcrc, IConsGasQn<ConsGasQn4000> qn4000, ICokeCbConsumptionDryCalc cbDry)
      {
         QcRc = qcrc;
         ConsGasQn = qn4000;
         WetGas = wetGas;
         CbDry = cbDry;
      }
      public IEnumerable<OutputKgDTO> CalcEntities(EnumerableData data)
      {
         var Data = data as OutputKgEnumData;

         var d =
            from t1charDg in Data.CharacteristicsDg
            join t2kip in Data.Kip on new { t1charDg.Date } equals new { t2kip.Date }
            join t3charKg in Data.CharacteristicsKg on new { t2kip.Date } equals new { t3charKg.Date }
            join t4pressure in Data.Pressure on new { t3charKg.Date } equals new { t4pressure.Date }
            join t5ammountCb in Data.AmmountCbs on new { t4pressure.Date } equals new { t5ammountCb.Date }
            select new OutputKgData
            {
               CharacteristicsDg = t1charDg,
               Kip = t2kip,
               CharacteristicsKg = t3charKg,
               Pressure = t4pressure,
               AmmountCb = t5ammountCb,
            };

         List<OutputKgDTO> kgDTO = new List<OutputKgDTO>(d.Count());

         foreach (var item in d)
         {
            kgDTO.Add(CalcEntity(item));
         }
         return kgDTO;
      }

      public OutputKgDTO CalcEntity(Data data)
      {
         OutputKgData Data = data as OutputKgData;
         var kip = data.Kip;
         var charKg = data.CharacteristicsKg;
         var cbs = Data.AmmountCb;

         var wetGas = WetGas.CalcEntity(data);

         var CbDryConsumption = CbDry.CalcEntity(cbs);

         return new OutputKgDTO
         {
            Date = wetGas.Date,
            QcRcCu1 = QcRc.Calc(kip.Cu.Cu1.Consumption.Value, wetGas.Cu.Cu1, kip.Cu.Cu1.Temperature, charKg.Kc1.Density),
            QcRcCu2 = QcRc.Calc(kip.Cu.Cu2.Consumption.Value, wetGas.Cu.Cu2, kip.Cu.Cu2.Temperature, charKg.Kc2.Density),
            Cu14000 = ConsGasQn.Calc(QcRc.Calc(kip.Cu.Cu1.Consumption.Value, wetGas.Cu.Cu1, kip.Cu.Cu1.Temperature, charKg.Kc1.Density), charKg.Kc1.Qn),
            Cu24000 = ConsGasQn.Calc(QcRc.Calc(kip.Cu.Cu2.Consumption.Value, wetGas.Cu.Cu2, kip.Cu.Cu2.Temperature, charKg.Kc2.Density), charKg.Kc1.Qn),
            Cu1Cb16 = ConsGasQn.Calc(QcRc.Calc(kip.Cu.Cu1.Consumption.Value, wetGas.Cu.Cu1, kip.Cu.Cu1.Temperature, charKg.Kc1.Density), charKg.Kc1.Qn) / CbDryConsumption.Cb1_6,
            Cu2Cb78 = ConsGasQn.Calc(QcRc.Calc(kip.Cu.Cu2.Consumption.Value, wetGas.Cu.Cu2, kip.Cu.Cu2.Temperature, charKg.Kc2.Density), charKg.Kc1.Qn) / CbDryConsumption.Cb7_8,
            PrMk = QcRc.Calc(kip.Cu.Cu1.Consumption.Value, wetGas.Cu.Cu1, kip.Cu.Cu1.Temperature, charKg.Kc1.Density) +
            QcRc.Calc(kip.Cu.Cu2.Consumption.Value, wetGas.Cu.Cu2, kip.Cu.Cu2.Temperature, charKg.Kc2.Density),
            PrMk4000 = ConsGasQn.Calc(QcRc.Calc(kip.Cu.Cu1.Consumption.Value, wetGas.Cu.Cu1, kip.Cu.Cu1.Temperature, charKg.Kc1.Density), charKg.Kc1.Qn) +
               ConsGasQn.Calc(QcRc.Calc(kip.Cu.Cu2.Consumption.Value, wetGas.Cu.Cu2, kip.Cu.Cu2.Temperature, charKg.Kc2.Density), charKg.Kc1.Qn),
            OutCgSh = (ConsGasQn.Calc(QcRc.Calc(kip.Cu.Cu1.Consumption.Value, wetGas.Cu.Cu1, kip.Cu.Cu1.Temperature, charKg.Kc1.Density), charKg.Kc1.Qn) +
               ConsGasQn.Calc(QcRc.Calc(kip.Cu.Cu2.Consumption.Value, wetGas.Cu.Cu2, kip.Cu.Cu2.Temperature, charKg.Kc2.Density), charKg.Kc1.Qn)) / (CbDryConsumption.Cb1_6 + CbDryConsumption.Cb7_8)
         };
      }
   }
}
