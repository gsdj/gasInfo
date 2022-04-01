using Business.BusinessModels.BaseCalculations;
using Business.BusinessModels.DataForCalculations;
using Business.DTO;
using Business.Interfaces.BaseCalculations;
using Business.Interfaces.Calculations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.BusinessModels.Calculations
{
   public class CalcOutputKG : ICalculation<OutputKgDTO>, ICalculations<OutputKgDTO>
   {
      private IQcRc QcRc;
      private IConsGasQn<ConsGasQn4000> ConsGasQn;
      private ICalculation<DensityDTO> WetGas;
      private IDryCokeProduction<DefaultDryCokeProduction> DryCoke;
      public CalcOutputKG(ICalculation<DensityDTO> wetGas, IQcRc qcrc, IConsGasQn<ConsGasQn4000> qn4000, 
                           IDryCokeProduction<DefaultDryCokeProduction> dryCoke)
      {
         QcRc = qcrc;
         ConsGasQn = qn4000;
         DryCoke = dryCoke;
         WetGas = wetGas;
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

         var Cb16ConsDry = Math.Round(((DryCoke.Calc(cbs.Cb1, cbs.OutputMultipliers.Cb1) + DryCoke.Calc(cbs.Cb2, cbs.OutputMultipliers.Cb2) +
                                       DryCoke.Calc(cbs.Cb3, cbs.OutputMultipliers.Cb3) + DryCoke.Calc(cbs.Cb4, cbs.OutputMultipliers.Cb4) +
                                       DryCoke.Calc(cbs.Cb5, cbs.OutputMultipliers.Cb5) + DryCoke.Calc(cbs.Cb6, cbs.OutputMultipliers.Cb6)) * cbs.OutputMultipliers.Sv), 4);

         var Cb78ConsDry = Math.Round((DryCoke.Calc(cbs.Cb7, cbs.OutputMultipliers.Cb7) + DryCoke.Calc(cbs.Cb8, cbs.OutputMultipliers.Cb8)) * cbs.OutputMultipliers.Sv, 4);


         return new OutputKgDTO
         {
            Date = wetGas.Date,
            QcRcCu1 = QcRc.Calc(kip.Cu1.Consumption, wetGas.Cu1, kip.Cu1.Temperature, charKg.Kc1.Characteristics.Density),
            QcRcCu2 = QcRc.Calc(kip.Cu2.Consumption, wetGas.Cu2, kip.Cu2.Temperature, charKg.Kc2.Characteristics.Density),
            Cu14000 = ConsGasQn.Calc(QcRc.Calc(kip.Cu1.Consumption, wetGas.Cu1, kip.Cu1.Temperature, charKg.Kc1.Characteristics.Density), charKg.Kc1.Characteristics.Qn),
            Cu24000 = ConsGasQn.Calc(QcRc.Calc(kip.Cu2.Consumption, wetGas.Cu2, kip.Cu2.Temperature, charKg.Kc2.Characteristics.Density), charKg.Kc1.Characteristics.Qn),
            Cu1Cb16 = ConsGasQn.Calc(QcRc.Calc(kip.Cu1.Consumption, wetGas.Cu1, kip.Cu1.Temperature, charKg.Kc1.Characteristics.Density), charKg.Kc1.Characteristics.Qn) / Cb16ConsDry,
            Cu2Cb78 = ConsGasQn.Calc(QcRc.Calc(kip.Cu2.Consumption, wetGas.Cu2, kip.Cu2.Temperature, charKg.Kc2.Characteristics.Density), charKg.Kc1.Characteristics.Qn) / Cb78ConsDry,
            PrMk = QcRc.Calc(kip.Cu1.Consumption, wetGas.Cu1, kip.Cu1.Temperature, charKg.Kc1.Characteristics.Density) +
            QcRc.Calc(kip.Cu2.Consumption, wetGas.Cu2, kip.Cu2.Temperature, charKg.Kc2.Characteristics.Density),
            PrMk4000 = ConsGasQn.Calc(QcRc.Calc(kip.Cu1.Consumption, wetGas.Cu1, kip.Cu1.Temperature, charKg.Kc1.Characteristics.Density), charKg.Kc1.Characteristics.Qn) +
               ConsGasQn.Calc(QcRc.Calc(kip.Cu2.Consumption, wetGas.Cu2, kip.Cu2.Temperature, charKg.Kc2.Characteristics.Density), charKg.Kc1.Characteristics.Qn),
            OutCgSh = (ConsGasQn.Calc(QcRc.Calc(kip.Cu1.Consumption, wetGas.Cu1, kip.Cu1.Temperature, charKg.Kc1.Characteristics.Density), charKg.Kc1.Characteristics.Qn) +
               ConsGasQn.Calc(QcRc.Calc(kip.Cu2.Consumption, wetGas.Cu2, kip.Cu2.Temperature, charKg.Kc2.Characteristics.Density), charKg.Kc1.Characteristics.Qn)) / (Cb16ConsDry + Cb78ConsDry)
         };
      }
   }
}
