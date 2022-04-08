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
   public class CalcConsumptionDgPg : ICalculation<ConsumptionDgPgDTO>, ICalculations<ConsumptionDgPgDTO>
   {
      private ICalculation<DensityDTO> WetGas;
      private IConsPg ConsPg;
      private IConsPgCb ConsPgCb;
      private IConsGasQn<ConsGasQn1000> ConsGasQn;
      private IQcRc QcRc;
      private IUdConsDgFv UdConsDgFv;
      private IChargeConsFV<DefaultChargeConsFV> ConsCbFv;
      public CalcConsumptionDgPg(ICalculation<DensityDTO> wetGas, IConsPg consPg, IConsPgCb consPgCb, 
         IConsGasQn<ConsGasQn1000> consGasQn, IQcRc qcRc, IUdConsDgFv udConsDgFv, IChargeConsFV<DefaultChargeConsFV> consFv)
      {
         ConsPg = consPg;
         ConsPgCb = consPgCb;
         ConsGasQn = consGasQn;
         QcRc = qcRc;
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

         var ConsFvKc1 = new ConsumptionKc1<decimal>
         {
            Cb1 = ConsCbFv.Calc(cbs.Cb1, cbs.OutputMultipliers.Cb1, cbs.OutputMultipliers.Fv),
            Cb2 = ConsCbFv.Calc(cbs.Cb2, cbs.OutputMultipliers.Cb2, cbs.OutputMultipliers.Fv),
            Cb3 = ConsCbFv.Calc(cbs.Cb3, cbs.OutputMultipliers.Cb3, cbs.OutputMultipliers.Fv),
            Cb4 = ConsCbFv.Calc(cbs.Cb4, cbs.OutputMultipliers.Cb4, cbs.OutputMultipliers.Fv),
         };

         var ConsFvKc2 = new ConsumptionKc2<decimal>
         {
            Cb5 = ConsCbFv.Calc(cbs.Cb5, cbs.OutputMultipliers.Cb5, cbs.OutputMultipliers.Fv),
            Cb6 = ConsCbFv.Calc(cbs.Cb6, cbs.OutputMultipliers.Cb6, cbs.OutputMultipliers.Fv),
            Cb7 = ConsCbFv.Calc(cbs.Cb7, cbs.OutputMultipliers.Cb7, cbs.OutputMultipliers.Fv),
            Cb8 = ConsCbFv.Calc(cbs.Cb8, cbs.OutputMultipliers.Cb8, cbs.OutputMultipliers.Fv),
         };

         var data1 = new
         {
            CbsConsFvSum = ConsFvKc1.Cb1 + ConsFvKc1.Cb2 + ConsFvKc1.Cb3 + ConsFvKc1.Cb4 +
                  ConsFvKc2.Cb5 + ConsFvKc2.Cb6 + ConsFvKc2.Cb7 + ConsFvKc2.Cb8,
            Kc1ConsFvSum = ConsFvKc1.Cb1 + ConsFvKc1.Cb2 + ConsFvKc1.Cb3 + ConsFvKc1.Cb4,
            Kc2ConsFvSum = ConsFvKc2.Cb5 + ConsFvKc2.Cb6 + ConsFvKc2.Cb7 + ConsFvKc2.Cb8,
            ConsPgKc1 = ConsPg.Calc(kip.Grp4.Consumption, data.Pressure.ValuePa, kip.Grp4.Pressure, kip.Grp4.Temperature),
         };

         var qcrcDg = new QcRcKc1
         {
            Cb1 = QcRc.Calc(kip.Cb1.Consumption, wetGas.Cb1, kip.Cb1.Temperature, charDg.Kc1.Characteristics.Density),
            Cb2 = QcRc.Calc(kip.Cb2.Consumption, wetGas.Cb2, kip.Cb2.Temperature, charDg.Kc1.Characteristics.Density),
            Cb3 = QcRc.Calc(kip.Cb3.Consumption, wetGas.Cb3, kip.Cb3.Temperature, charDg.Kc2.Characteristics.Density),
            Cb4 = QcRc.Calc(kip.Cb4.Consumption, wetGas.Cb4, kip.Cb4.Temperature, charDg.Kc2.Characteristics.Density),
         };

         var consDg = new ConsumptionKc1<decimal>
         {
            Cb1 = ConsGasQn.Calc(qcrcDg.Cb1, charDg.Kc1.Characteristics.Qn),
            Cb2 = ConsGasQn.Calc(qcrcDg.Cb2, charDg.Kc1.Characteristics.Qn),
            Cb3 = ConsGasQn.Calc(qcrcDg.Cb3, charDg.Kc2.Characteristics.Qn),
            Cb4 = ConsGasQn.Calc(qcrcDg.Cb4, charDg.Kc2.Characteristics.Qn),
         };

         var consPgGru = new ConsumptionGru<decimal>
         {
            Gru1 = ConsPg.Calc(kip.Gru1.Consumption, data.Pressure.ValuePa, kip.Gru1.Pressure, kip.Gru1.Temperature),
            Gru2 = ConsPg.Calc(kip.Gru2.Consumption, data.Pressure.ValuePa, kip.Gru2.Pressure, kip.Gru2.Temperature),
         };

         var consPgCb = new ConsumptionKc1<decimal>
         {
            Cb1 = ConsPgCb.Calc(consDg.Cb1, data1.ConsPgKc1, consDg.Cb1 + consDg.Cb2 + consDg.Cb3 + consDg.Cb4),
            Cb2 = ConsPgCb.Calc(consDg.Cb2, data1.ConsPgKc1, consDg.Cb1 + consDg.Cb2 + consDg.Cb3 + consDg.Cb4),
            Cb3 = ConsPgCb.Calc(consDg.Cb3, data1.ConsPgKc1, consDg.Cb1 + consDg.Cb2 + consDg.Cb3 + consDg.Cb4),
            Cb4 = ConsPgCb.Calc(consDg.Cb4, data1.ConsPgKc1, consDg.Cb1 + consDg.Cb2 + consDg.Cb3 + consDg.Cb4),
         };

         var udConsPgGru = new ConsumptionGru<decimal>
         {
            Gru1 = consPgGru.Gru1 / data1.CbsConsFvSum / 0.4m,
            Gru2 = consPgGru.Gru2 / data1.CbsConsFvSum / 0.6m,
         };

         var udConsKgFv = new ConsumptionKc1<decimal>
         {
            Cb1 = UdConsDgFv.Calc(consDg.Cb1, consPgCb.Cb1, ConsFvKc1.Cb1),
            Cb2 = UdConsDgFv.Calc(consDg.Cb2, consPgCb.Cb2, ConsFvKc1.Cb2),
            Cb3 = UdConsDgFv.Calc(consDg.Cb3, consPgCb.Cb3, ConsFvKc1.Cb3),
            Cb4 = UdConsDgFv.Calc(consDg.Cb4, consPgCb.Cb4, ConsFvKc1.Cb4),
         };

         return new ConsumptionDgPgDTO
         {
            Date = wetGas.Date,
            ConsumptionDgCb = consDg,
            ConsumptionDgKc1 = consDg.Cb1 + consDg.Cb2 + consDg.Cb3 + consDg.Cb4,
            ConsumptionPgCb = consPgCb,
            ConsumptionPgKc1 = data1.ConsPgKc1,
            ConsumptionPgGru = consPgGru,
            UdConsumptionPgGru = udConsPgGru,
            UdConsumptionKgFvCb = udConsKgFv,
            UdConsumptionKgFvKc1 = UdConsDgFv.Calc(consDg.Cb1 + consDg.Cb2 + consDg.Cb3 + consDg.Cb4, data1.ConsPgKc1, data1.Kc1ConsFvSum),
         };
      }
   }
}
