using Business.DTO;
using Business.DTO.Characteristics;
using Business.DTO.Consumption;
using Business.DTO.QcRc;
using Business.Interfaces.Calculations;
using Bussiness.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessModels.Calculations
{
   public class CalcConsumptionDgPg : ICalcConsumptionDgPg
   {
      private Dictionary<int, SteamCharacteristicsDTO> _steam;
      public IEnumerable<ConsumptionDgPgDTO> CalcEntities(IEnumerable<DensityDTO> wetGas, IEnumerable<DevicesKipDTO> kips, 
         IEnumerable<ProductionDTO> prod, IEnumerable<CharacteristicsDgDTO> charDgs, 
         IEnumerable<PressureDTO> pressure, Dictionary<int, SteamCharacteristicsDTO> steam)
      {
         _steam = steam;
         List<ConsumptionDgPgDTO> consdgpgDTO = new List<ConsumptionDgPgDTO>(wetGas.Count());
         var data =
            from t1wetGas in wetGas
            join t2kip in kips on new { t1wetGas.Date } equals new { t2kip.Date }
            join t3charDg in charDgs on new { t2kip.Date } equals new { t3charDg.Date }
            join t4prod in prod on new { t3charDg.Date } equals new { t4prod.Date }
            join t5p in pressure on new { t4prod.Date } equals new { t5p.Date }
            select new
            {
               WetGas = t1wetGas,
               Kip = t2kip,
               CharDg = t3charDg,
               Prod = t4prod,
               Pressure = t5p,
            };
         foreach (var item in data)
         {
            consdgpgDTO.Add(CalcEntity(item.WetGas, item.Kip, item.Prod, item.CharDg, item.Pressure));
         }
         return consdgpgDTO;
      }

      public ConsumptionDgPgDTO CalcEntity(DensityDTO wetGas, DevicesKipDTO kip, ProductionDTO prod, CharacteristicsDgDTO charDg, PressureDTO pressure)
      {
         var data = new
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
            Cb1 = Qn1000(qcrcDg.Cb1, charDg.Kc1.Characteristics.Qn),
            Cb2 = Qn1000(qcrcDg.Cb2, charDg.Kc1.Characteristics.Qn),
            Cb3 = Qn1000(qcrcDg.Cb3, charDg.Kc2.Characteristics.Qn),
            Cb4 = Qn1000(qcrcDg.Cb4, charDg.Kc2.Characteristics.Qn),
         };

         var consPgGru = new ConsumptionGru<decimal>
         {
            Gru1 = ConsPg(kip.Gru1.Consumption, pressure.ValuePa, kip.Gru1.Pressure, kip.Gru1.Temperature),
            Gru2 = ConsPg(kip.Gru2.Consumption, pressure.ValuePa, kip.Gru2.Pressure, kip.Gru2.Temperature),
         };

         var consPgCb = new ConsumptionKc1<decimal>
         {
            Cb1 = ConsPgCb(consDg.Cb1, data.ConsPgKc1, consDg.Cb1 + consDg.Cb2 + consDg.Cb3 + consDg.Cb4),
            Cb2 = ConsPgCb(consDg.Cb2, data.ConsPgKc1, consDg.Cb1 + consDg.Cb2 + consDg.Cb3 + consDg.Cb4),
            Cb3 = ConsPgCb(consDg.Cb3, data.ConsPgKc1, consDg.Cb1 + consDg.Cb2 + consDg.Cb3 + consDg.Cb4),
            Cb4 = ConsPgCb(consDg.Cb4, data.ConsPgKc1, consDg.Cb1 + consDg.Cb2 + consDg.Cb3 + consDg.Cb4),
         };

         var udConsPgGru = new ConsumptionGru<decimal>
         {
            Gru1 = consPgGru.Gru1 / data.CbsConsFvSum / 0.4m,
            Gru2 = consPgGru.Gru2 / data.CbsConsFvSum / 0.6m,
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
            ConsumptionPgKc1 = data.ConsPgKc1,
            ConsumptionPgGru = consPgGru,
            UdConsumptionPgGru = udConsPgGru,
            UdConsumptionKgFvCb = udConsKgFv,
            UdConsumptionKgFvKc1 = UdConsDgFv(consDg.Cb1 + consDg.Cb2 + consDg.Cb3 + consDg.Cb4, data.ConsPgKc1, data.Kc1ConsFvSum),
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

      public decimal QcRc(decimal cons, decimal wetGas, decimal temp, decimal density)
      {
         if (cons == 0 || wetGas == 0 || density == 0)
            return 0;

         int tempRounded = Convert.ToInt32(Math.Round(temp, MidpointRounding.ToEven));
         decimal Fkg = _steam[tempRounded].Fkg;

         decimal result = (cons * wetGas) * (1 - Fkg / wetGas) * 1 / density;
         return Math.Round(result, 10);
      }

      public decimal Qn1000(decimal qcrc, decimal qn)
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
