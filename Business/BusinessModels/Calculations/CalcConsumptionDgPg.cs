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
   public class CalcConsumptionDgPg : ICalculation<ConsumptionDgPgDTO>, ICalculations<ConsumptionDgPgDTO>, IQcRc, IQn1, IConsPg, IConsPgCb, IUdConsDgFv
   {
      private Dictionary<int, SteamCharacteristicsDTO> _steam;
      private IConstantsAll _cAll;
      private Constants Constants;
      public CalcConsumptionDgPg(IConstantsAll cAll)
      {
         _cAll = cAll;
         Constants = _cAll.GetConstants();
         _steam = _cAll.GetSteamCharacteristics();
      }

      public IEnumerable<ConsumptionDgPgDTO> CalcEntities(EnumerableData data)
      {
         var Data = data as ConsumptionDgPgEnumData;
         var wetGas = Data.WetGas;
         var kip = Data.Kip;
         var charDg = Data.CharacteristicsDg;
         var prod = Data.Production;
         var pressure = Data.Pressure;

         
         var d =
            from t1wetGas in wetGas
            join t2kip in kip on new { t1wetGas.Date } equals new { t2kip.Date }
            join t3charDg in charDg on new { t2kip.Date } equals new { t3charDg.Date }
            join t4prod in prod on new { t3charDg.Date } equals new { t4prod.Date }
            join t5p in pressure on new { t4prod.Date } equals new { t5p.Date }
            select new ConsumptionDgPgData
            {
               WetGas = t1wetGas,
               Kip = t2kip,
               CharacteristicsDg = t3charDg,
               Production = t4prod,
               Pressure = t5p,
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
         ConsumptionDgPgData Data = data as ConsumptionDgPgData;
         var prod = Data.Production;
         var pressure = Data.Pressure;
         var kip = Data.Kip;
         var wetGas = Data.WetGas;
         var charDg = Data.CharacteristicsDg;

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
            Cb1 = QcRc(kip.Cb1.Consumption, wetGas.Cb1, kip.Cb1.Temperature, charDg.Kc1.Characteristics.Density),
            Cb2 = QcRc(kip.Cb2.Consumption, wetGas.Cb2, kip.Cb2.Temperature, charDg.Kc1.Characteristics.Density),
            Cb3 = QcRc(kip.Cb3.Consumption, wetGas.Cb3, kip.Cb3.Temperature, charDg.Kc2.Characteristics.Density),
            Cb4 = QcRc(kip.Cb4.Consumption, wetGas.Cb4, kip.Cb4.Temperature, charDg.Kc2.Characteristics.Density),
         };

         var consDg = new ConsumptionKc1<decimal>
         {
            Cb1 = Qn(qcrcDg.Cb1, charDg.Kc1.Characteristics.Qn),
            Cb2 = Qn(qcrcDg.Cb2, charDg.Kc1.Characteristics.Qn),
            Cb3 = Qn(qcrcDg.Cb3, charDg.Kc2.Characteristics.Qn),
            Cb4 = Qn(qcrcDg.Cb4, charDg.Kc2.Characteristics.Qn),
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

         decimal result = cons * Constants.Tc * (PPa + pressure * Constants.PexcC) / ((Constants.TpC + temp) * Constants.Pc * 1);
         return Math.Round(result, 10);
      }

      public decimal ConsPgCb(decimal consDg, decimal consPgKc, decimal kcSum)
      {
         if (consDg == 0 || consPgKc == 0 || kcSum == 0)
            return 0;

         decimal result = consPgKc * (consDg / kcSum);
         return Math.Round(result, 10);
      }

      public decimal QcRc(decimal cons, decimal wetGas, decimal temp, decimal density, bool perHour = false)
      {
         if (cons == 0 || wetGas == 0 || density == 0)
            return 0;

         int tempRounded = Convert.ToInt32(Math.Round(temp, MidpointRounding.ToEven));
         decimal Fkg = _steam[tempRounded].Fkg;

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

      public decimal Qn(decimal qcrc, decimal qn)
      {
         if (qcrc == 0 || qn == 0)
            return 0;

         return Math.Round((qcrc * qn / 1000), 10);
      }

      public decimal UdConsDgFv(decimal consDg, decimal consPg, decimal consFv)
      {
         if (consDg == 0 || consPg == 0 || consFv == 0)
            return 0;

         decimal result = ((consDg * Constants.UdDgC) + (consPg * Constants.UdPgC)) / consFv;
         return Math.Round(result, 10);
      }
   }
}
