using Business.BusinessModels.BaseCalculations.Consumption;
using Business.BusinessModels.DataForCalculations;
using Business.DTO;
using Business.DTO.General;
using Business.Interfaces.BaseCalculations.Consumption;
using Business.Interfaces.Calculations;
using Business.Interfaces.Calculations.ConsGasQn;
using System.Collections.Generic;
using System.Linq;

namespace Business.BusinessModels.Calculations
{
   public class CalcConsumptionDgPg : ICalculation<ConsumptionDgPgDTO>, ICalculations<ConsumptionDgPgDTO>
   {
      private ICalculation<DensityDTO> WetGas;
      private ICalcConsGasQnKc1 ConsGasQn;
      private IConsPg ConsPg;
      private IConsPgCb ConsPgCb;
      private IUdConsDgFv UdConsDgFv;
      private IChargeConsFV<DefaultChargeConsFV> ConsCbFv;
      public CalcConsumptionDgPg(ICalculation<DensityDTO> wetGas, IConsPg consPg, IConsPgCb consPgCb,
         ICalcConsGasQnKc1 consQn, IUdConsDgFv udConsDgFv, IChargeConsFV<DefaultChargeConsFV> consFv)
      {
         ConsPg = consPg;
         ConsPgCb = consPgCb;
         ConsGasQn = consQn;
         UdConsDgFv = udConsDgFv;
         ConsCbFv = consFv;
      }

      public IEnumerable<ConsumptionDgPgDTO> CalcEntities(EnumerableData data)
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

         List<ConsumptionDgPgDTO> consdgpgDTO = new List<ConsumptionDgPgDTO>(d.Count());

         foreach (var item in d)
         {
            consdgpgDTO.Add(CalcEntity(item));
         }
         return consdgpgDTO;
      }

      public ConsumptionDgPgDTO CalcEntity(Data data)
      {
         OutputKgData Data = data as OutputKgData;
         var kip = data.Kip;
         var charDg = data.CharacteristicsDg;
         var cbs = Data.AmmountCb;

         var wetGas = WetGas.CalcEntity(data);

         var qcrcData = new QcRcDgData
         {
            CharacteristicsDg = charDg,
            Kip = kip,
            WetGas = wetGas,
         };

         var ConsFvKc = new CbAll
         {
            Kc1 =
            {
               Cb1 = ConsCbFv.Calc(cbs.Cb1, cbs.OutputMultipliers.Cb1, cbs.OutputMultipliers.Fv),
               Cb2 = ConsCbFv.Calc(cbs.Cb2, cbs.OutputMultipliers.Cb2, cbs.OutputMultipliers.Fv),
               Cb3 = ConsCbFv.Calc(cbs.Cb3, cbs.OutputMultipliers.Cb3, cbs.OutputMultipliers.Fv),
               Cb4 = ConsCbFv.Calc(cbs.Cb4, cbs.OutputMultipliers.Cb4, cbs.OutputMultipliers.Fv),
            },
            Kc2 =
            {
               Cb1 = ConsCbFv.Calc(cbs.Cb5, cbs.OutputMultipliers.Cb5, cbs.OutputMultipliers.Fv),
               Cb2 = ConsCbFv.Calc(cbs.Cb6, cbs.OutputMultipliers.Cb6, cbs.OutputMultipliers.Fv),
               Cb3 = ConsCbFv.Calc(cbs.Cb7, cbs.OutputMultipliers.Cb7, cbs.OutputMultipliers.Fv),
               Cb4 = ConsCbFv.Calc(cbs.Cb8, cbs.OutputMultipliers.Cb8, cbs.OutputMultipliers.Fv),
            },
         };

         var data1 = new
         {
            CbsConsFvSum = ConsFvKc.Kc1.Cb1 + ConsFvKc.Kc1.Cb2 + ConsFvKc.Kc1.Cb3 + ConsFvKc.Kc1.Cb4 +
                           ConsFvKc.Kc2.Cb1 + ConsFvKc.Kc2.Cb2 + ConsFvKc.Kc2.Cb3 + ConsFvKc.Kc2.Cb4,
            Kc1ConsFvSum = ConsFvKc.Kc1.Cb1 + ConsFvKc.Kc1.Cb2 + ConsFvKc.Kc1.Cb3 + ConsFvKc.Kc1.Cb4,
            Kc2ConsFvSum = ConsFvKc.Kc2.Cb1 + ConsFvKc.Kc2.Cb2 + ConsFvKc.Kc2.Cb3 + ConsFvKc.Kc2.Cb4,
            ConsPgKc1 = ConsPg.Calc(kip.Grp4.Consumption.Value, data.Pressure.ValuePa, kip.Grp4.Pressure, kip.Grp4.Temperature),
         };

         var qcrcKc1 = ConsGasQn.CalcQcRcKc1.Calc(qcrcData);

         var consKc1 = ConsGasQn.Calc(qcrcKc1, charDg);

         var consPgGru = new Gru
         {
            Gru1 = ConsPg.Calc(kip.Gru.Gru1.Consumption.Value, data.Pressure.ValuePa, kip.Gru.Gru1.Pressure, kip.Gru.Gru1.Temperature),
            Gru2 = ConsPg.Calc(kip.Gru.Gru2.Consumption.Value, data.Pressure.ValuePa, kip.Gru.Gru2.Pressure, kip.Gru.Gru2.Temperature),
         };

         var consPgCb = new CbKc
         {
            Cb1 = ConsPgCb.Calc(consKc1.Cb1, data1.ConsPgKc1, consKc1.Cb1 + consKc1.Cb2 + consKc1.Cb3 + consKc1.Cb4),
            Cb2 = ConsPgCb.Calc(consKc1.Cb2, data1.ConsPgKc1, consKc1.Cb1 + consKc1.Cb2 + consKc1.Cb3 + consKc1.Cb4),
            Cb3 = ConsPgCb.Calc(consKc1.Cb3, data1.ConsPgKc1, consKc1.Cb1 + consKc1.Cb2 + consKc1.Cb3 + consKc1.Cb4),
            Cb4 = ConsPgCb.Calc(consKc1.Cb4, data1.ConsPgKc1, consKc1.Cb1 + consKc1.Cb2 + consKc1.Cb3 + consKc1.Cb4),
         };

         var udConsPgGru = new Gru
         {
            Gru1 = consPgGru.Gru1 / data1.CbsConsFvSum / 0.4m,
            Gru2 = consPgGru.Gru2 / data1.CbsConsFvSum / 0.6m,
         };

         var udConsKgFv = new CbKc
         {
            Cb1 = UdConsDgFv.Calc(consKc1.Cb1, consPgCb.Cb1, ConsFvKc.Kc1.Cb1),
            Cb2 = UdConsDgFv.Calc(consKc1.Cb2, consPgCb.Cb2, ConsFvKc.Kc1.Cb2),
            Cb3 = UdConsDgFv.Calc(consKc1.Cb3, consPgCb.Cb3, ConsFvKc.Kc1.Cb3),
            Cb4 = UdConsDgFv.Calc(consKc1.Cb4, consPgCb.Cb4, ConsFvKc.Kc1.Cb4),
         };

         return new ConsumptionDgPgDTO
         {
            Date = wetGas.Date,
            ConsumptionDgCb = consKc1,
            ConsumptionDgKc1 = consKc1.Cb1 + consKc1.Cb2 + consKc1.Cb3 + consKc1.Cb4,
            ConsumptionPgCb = consPgCb,
            ConsumptionPgKc1 = data1.ConsPgKc1,
            ConsumptionPgGru = consPgGru,
            UdConsumptionPgGru = udConsPgGru,
            UdConsumptionKgFvCb = udConsKgFv,
            UdConsumptionKgFvKc1 = UdConsDgFv.Calc(consKc1.Cb1 + consKc1.Cb2 + consKc1.Cb3 + consKc1.Cb4, data1.ConsPgKc1, data1.Kc1ConsFvSum),
         };
      }
   }
}
