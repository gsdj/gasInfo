using Business.BusinessModels.BaseCalculations;
using Business.BusinessModels.DataForCalculations;
using Business.DTO;
using Business.DTO.Characteristics;
using Business.DTO.Consumption;
using Business.DTO.QcRc;
using Business.Interfaces;
using Business.Interfaces.BaseCalculations;
using Business.Interfaces.Calculations;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.BusinessModels.Calculations
{
   public class CalcConsumptionDgPg : ICalculation<ConsumptionDgPgDTO>, ICalculations<ConsumptionDgPgDTO>, IQcRc, IConsGasQn<CalcConsumptionDgPg>, IConsPg, IConsPgCb, IUdConsDgFv
   {
      private Dictionary<int, SteamCharacteristicsDTO> SteamCharacteristics;
      private ISteamCharacteristicsService steamService;
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
         steamService = st;
         SteamCharacteristics = steamService.GetCharacteristics();
         ConsPg = consPg;
         ConsPgCb = consPgCb;
         consGasQn = consGasQn;
         QcRc = qcRc;
         UdConsDgFv = udConsDgFv;
         ConsCbFv = consFv;
      }

      public ISteamCharacteristicsService SteamCharacteristicsService
      {
         get
         {
            return steamService;
         }
         set
         {
            steamService = value;
            if (SteamCharacteristics == null || SteamCharacteristics.Count == 0)
               SteamCharacteristics = value.GetCharacteristics();
         }
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
         var charKg = data.CharacteristicsKg;
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
         },

         var data1 = new
         {
            CbsConsFvSum = prod.ConsumptionFvKc1.Cb1 + prod.ConsumptionFvKc1.Cb2 + prod.ConsumptionFvKc1.Cb3 + prod.ConsumptionFvKc1.Cb4 +
                  prod.ConsumptionFvKc2.Cb5 + prod.ConsumptionFvKc2.Cb6 + prod.ConsumptionFvKc2.Cb7 + prod.ConsumptionFvKc2.Cb8,
            Kc1ConsFvSum = prod.ConsumptionFvKc1.Cb1 + prod.ConsumptionFvKc1.Cb2 + prod.ConsumptionFvKc1.Cb3 + prod.ConsumptionFvKc1.Cb4,
            Kc2ConsFvSum = prod.ConsumptionFvKc2.Cb5 + prod.ConsumptionFvKc2.Cb6 + prod.ConsumptionFvKc2.Cb7 + prod.ConsumptionFvKc2.Cb8,
            ConsPgKc1 = ConsPg(kip.Grp4.Consumption, pressure.ValuePa, kip.Grp4.Pressure, kip.Grp4.Temperature),
         };

         var qcrcDg = new QcRcKc1
         {
            Cb1 = Calc(kip.Cb1.Consumption, wetGas.Cb1, kip.Cb1.Temperature, charDg.Kc1.Characteristics.Density),
            Cb2 = Calc(kip.Cb2.Consumption, wetGas.Cb2, kip.Cb2.Temperature, charDg.Kc1.Characteristics.Density),
            Cb3 = Calc(kip.Cb3.Consumption, wetGas.Cb3, kip.Cb3.Temperature, charDg.Kc2.Characteristics.Density),
            Cb4 = Calc(kip.Cb4.Consumption, wetGas.Cb4, kip.Cb4.Temperature, charDg.Kc2.Characteristics.Density),
         };

         var consDg = new ConsumptionKc1<decimal>
         {
            Cb1 = Calc(qcrcDg.Cb1, charDg.Kc1.Characteristics.Qn),
            Cb2 = Calc(qcrcDg.Cb2, charDg.Kc1.Characteristics.Qn),
            Cb3 = Calc(qcrcDg.Cb3, charDg.Kc2.Characteristics.Qn),
            Cb4 = Calc(qcrcDg.Cb4, charDg.Kc2.Characteristics.Qn),
         };

         var consPgGru = new ConsumptionGru<decimal>
         {
            Gru1 = ConsPg(kip.Gru1.Consumption, pressure.ValuePa, kip.Gru1.Pressure, kip.Gru1.Temperature),
            Gru2 = ConsPg(kip.Gru2.Consumption, pressure.ValuePa, kip.Gru2.Pressure, kip.Gru2.Temperature),
         };

         var consPgCb = new ConsumptionKc1<decimal>
         {
            Cb1 = ConsPgCb(consDg.Cb1, data1.ConsPgKc1, consDg.Cb1 + consDg.Cb2 + consDg.Cb3 + consDg.Cb4),
            Cb2 = ConsPgCb(consDg.Cb2, data1.ConsPgKc1, consDg.Cb1 + consDg.Cb2 + consDg.Cb3 + consDg.Cb4),
            Cb3 = ConsPgCb(consDg.Cb3, data1.ConsPgKc1, consDg.Cb1 + consDg.Cb2 + consDg.Cb3 + consDg.Cb4),
            Cb4 = ConsPgCb(consDg.Cb4, data1.ConsPgKc1, consDg.Cb1 + consDg.Cb2 + consDg.Cb3 + consDg.Cb4),
         };

         var udConsPgGru = new ConsumptionGru<decimal>
         {
            Gru1 = consPgGru.Gru1 / data1.CbsConsFvSum / 0.4m,
            Gru2 = consPgGru.Gru2 / data1.CbsConsFvSum / 0.6m,
         };

         var udConsKgFv = new ConsumptionKc1<decimal>
         {
            Cb1 = UdConsDgFv(consDg.Cb1, consPgCb.Cb1, prod.ConsumptionFvKc1.Cb1),
            Cb2 = UdConsDgFv(consDg.Cb2, consPgCb.Cb2, prod.ConsumptionFvKc1.Cb2),
            Cb3 = UdConsDgFv(consDg.Cb3, consPgCb.Cb3, prod.ConsumptionFvKc1.Cb3),
            Cb4 = UdConsDgFv(consDg.Cb4, consPgCb.Cb4, prod.ConsumptionFvKc1.Cb4),
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
            UdConsumptionKgFvKc1 = UdConsDgFv(consDg.Cb1 + consDg.Cb2 + consDg.Cb3 + consDg.Cb4, data1.ConsPgKc1, data1.Kc1ConsFvSum),
         };
      }

      public decimal ConsPg(decimal cons, decimal PPa, decimal pressure, decimal temp)
      {
         if (cons == 0 || pressure == 0)
            return 0;

         decimal result = cons * GasConstants.Tc * (PPa + pressure * GasConstants.PexcC) / ((GasConstants.TpC + temp) * GasConstants.Pc * 1);
         return Math.Round(result, 10);
      }

      public decimal ConsPgCb(decimal consDg, decimal consPgKc, decimal kcSum)
      {
         if (consDg == 0 || consPgKc == 0 || kcSum == 0)
            return 0;

         decimal result = consPgKc * (consDg / kcSum);
         return Math.Round(result, 10);
      }

      public decimal Calc(decimal cons, decimal wetGas, decimal temp, decimal density, bool perHour = false)
      {
         if (cons == 0 || wetGas == 0 || density == 0)
            return 0;

         int tempRounded = Convert.ToInt32(Math.Round(temp, MidpointRounding.ToEven));
         decimal Fkg = SteamCharacteristics[tempRounded].Fkg;

         if (!perHour)
         {
            decimal result = (cons * wetGas) * (1 - Fkg / wetGas) * 1 / density;
            return Math.Round(result, 10);
         }
         else
         {
            decimal result = (cons * 24 * wetGas) * (1 - Fkg / wetGas) * 1 / density;
            return Math.Round(result, 10);
         }
      }

      public decimal Calc(decimal qcrc, decimal qn)
      {
         if (qcrc == 0 || qn == 0)
            return 0;

         return Math.Round((qcrc * qn / 1000), 10);
      }

      public decimal UdConsDgFv(decimal consDg, decimal consPg, decimal consFv)
      {
         if (consDg == 0 || consPg == 0 || consFv == 0)
            return 0;

         decimal result = ((consDg * GasConstants.UdDgC) + (consPg * GasConstants.UdPgC)) / consFv;
         return Math.Round(result, 10);
      }
   }
}
