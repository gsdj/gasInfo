using Business.BusinessModels.DataForCalculations;
using Business.DTO;
using Business.DTO.Consumption;
using Business.DTO.Models.General;
using Business.Interfaces.BaseCalculations.Consumption;
using Business.Interfaces.BaseCalculations.Production;
using Business.Interfaces.Calculations;
using Business.Interfaces.Calculations.ConsGasQn;
using System.Collections.Generic;
using System.Linq;

namespace Business.BusinessModels.Calculations.Consumption
{
   public class DefaultConsumptionDgPg : ICalculation<ConsumptionDgPgDTO>, ICalculations<ConsumptionDgPgDTO>
   {
      private ICalculation<DensityDTO> WetGas;
      private ICalcConsGasQnKc1 ConsGasQn;
      private IConsPg ConsPg;
      private IConsPgCb ConsPgCb;
      private ISpecificConsDgFv UdConsDgFv;
      private ICokeCbConsumptionFvCalc CbFv;
      public DefaultConsumptionDgPg(ICalculation<DensityDTO> wetGas, IConsPg consPg, IConsPgCb consPgCb,
         ICalcConsGasQnKc1 consQn, ISpecificConsDgFv udConsDgFv, ICokeCbConsumptionFvCalc cbFv)
      {
         WetGas = wetGas;
         ConsPg = consPg;
         ConsPgCb = consPgCb;
         ConsGasQn = consQn;
         UdConsDgFv = udConsDgFv;
         CbFv = cbFv;
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

         var ConsFvKc = CbFv.CalcEntity(cbs);

         var ConsPgKc1 = ConsPg.Calc(kip.Grp4.Consumption.Value, data.Pressure.ValuePa, kip.Grp4.Pressure, kip.Grp4.Temperature);

         var qcrcKc1 = ConsGasQn.CalcQcRcKc1.Calc(qcrcData);

         var consKc1 = ConsGasQn.Calc(qcrcKc1, charDg);

         var consPgGru = new Gru
         {
            Gru1 = ConsPg.Calc(kip.Gru.Gru1.Consumption.Value, data.Pressure.ValuePa, kip.Gru.Gru1.Pressure, kip.Gru.Gru1.Temperature),
            Gru2 = ConsPg.Calc(kip.Gru.Gru2.Consumption.Value, data.Pressure.ValuePa, kip.Gru.Gru2.Pressure, kip.Gru.Gru2.Temperature),
         };

         var consPgCb = new CbKc
         {
            Cb1 = ConsPgCb.Calc(consKc1.Cb1, ConsPgKc1, consKc1.Sum),
            Cb2 = ConsPgCb.Calc(consKc1.Cb2, ConsPgKc1, consKc1.Sum),
            Cb3 = ConsPgCb.Calc(consKc1.Cb3, ConsPgKc1, consKc1.Sum),
            Cb4 = ConsPgCb.Calc(consKc1.Cb4, ConsPgKc1, consKc1.Sum),
         };

         var udConsPgGru = new Gru
         {
            Gru1 = consPgGru.Gru1 / ConsFvKc.Kc1.Sum + ConsFvKc.Kc2.Sum / 0.4m,
            Gru2 = consPgGru.Gru2 / ConsFvKc.Kc1.Sum + ConsFvKc.Kc2.Sum / 0.6m,
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
            ConsumptionDgKc1 = consKc1.Sum,
            ConsumptionPgCb = consPgCb,
            ConsumptionPgKc1 = ConsPgKc1,
            ConsumptionPgGru = consPgGru,
            UdConsumptionPgGru = udConsPgGru,
            UdConsumptionKgFvCb = udConsKgFv,
            UdConsumptionKgFvKc1 = UdConsDgFv.Calc(consKc1.Sum, ConsPgKc1, ConsFvKc.Kc1.Sum),
         };
      }
   }
}
