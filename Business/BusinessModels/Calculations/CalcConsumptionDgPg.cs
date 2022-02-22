using Business.DTO;
using Business.DTO.Characteristics;
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
            CbsConsFvSum = prod.Cb1ConsFv + prod.Cb2ConsFv + prod.Cb3ConsFv + prod.Cb4ConsFv +
                           prod.Cb5ConsFv + prod.Cb6ConsFv + prod.Cb7ConsFv + prod.Cb8ConsFv,
            QcRcDgCb1 = QcRc(kip.Cb1.Consumption, wetGas.Cb1, kip.Cb1.Temperature, charDg.Kc1.Characteristics.Density),
            QcRcDgCb2 = QcRc(kip.Cb2.Consumption, wetGas.Cb2, kip.Cb2.Temperature, charDg.Kc1.Characteristics.Density),
            QcRcDgCb3 = QcRc(kip.Cb3.Consumption, wetGas.Cb3, kip.Cb3.Temperature, charDg.Kc2.Characteristics.Density),
            QcRcDgCb4 = QcRc(kip.Cb4.Consumption, wetGas.Cb4, kip.Cb4.Temperature, charDg.Kc2.Characteristics.Density),
            ConsPgKc1 = ConsPg(kip.Grp4.Consumption, pressure.ValuePa, kip.Grp4.Pressure, kip.Grp4.Temperature),
            ConsPgGru1 = ConsPg(kip.Gru1.Consumption, pressure.ValuePa, kip.Gru1.Pressure, kip.Gru1.Temperature),
            ConsPgGru2 = ConsPg(kip.Gru2.Consumption, pressure.ValuePa, kip.Gru2.Pressure, kip.Gru2.Temperature),
         };

         var data2 = new
         {
            ConsDgCb1 = Qn1000(data.QcRcDgCb1, charDg.Kc1.Characteristics.Qn),
            ConsDgCb2 = Qn1000(data.QcRcDgCb2, charDg.Kc1.Characteristics.Qn),
            ConsDgCb3 = Qn1000(data.QcRcDgCb3, charDg.Kc2.Characteristics.Qn),
            ConsDgCb4 = Qn1000(data.QcRcDgCb4, charDg.Kc2.Characteristics.Qn),
            Kc1Sum = Qn1000(data.QcRcDgCb1, charDg.Kc1.Characteristics.Qn) + Qn1000(data.QcRcDgCb2, charDg.Kc1.Characteristics.Qn) + 
                     Qn1000(data.QcRcDgCb3, charDg.Kc2.Characteristics.Qn) + Qn1000(data.QcRcDgCb4, charDg.Kc2.Characteristics.Qn),
            ConsPgCb1 = ConsPgCb(Qn1000(data.QcRcDgCb1, charDg.Kc1.Characteristics.Qn), data.ConsPgKc1,
                                    Qn1000(data.QcRcDgCb1, charDg.Kc1.Characteristics.Qn) + Qn1000(data.QcRcDgCb2, charDg.Kc1.Characteristics.Qn) +
                                    Qn1000(data.QcRcDgCb3, charDg.Kc2.Characteristics.Qn) + Qn1000(data.QcRcDgCb4, charDg.Kc2.Characteristics.Qn)),
            ConsPgCb2 = ConsPgCb(Qn1000(data.QcRcDgCb2, charDg.Kc1.Characteristics.Qn), data.ConsPgKc1,
                                    Qn1000(data.QcRcDgCb1, charDg.Kc1.Characteristics.Qn) + Qn1000(data.QcRcDgCb2, charDg.Kc1.Characteristics.Qn) +
                                    Qn1000(data.QcRcDgCb3, charDg.Kc2.Characteristics.Qn) + Qn1000(data.QcRcDgCb4, charDg.Kc2.Characteristics.Qn)),
            ConsPgCb3 = ConsPgCb(Qn1000(data.QcRcDgCb3, charDg.Kc2.Characteristics.Qn), data.ConsPgKc1,
                                    Qn1000(data.QcRcDgCb1, charDg.Kc1.Characteristics.Qn) + Qn1000(data.QcRcDgCb2, charDg.Kc1.Characteristics.Qn) +
                                    Qn1000(data.QcRcDgCb3, charDg.Kc2.Characteristics.Qn) + Qn1000(data.QcRcDgCb4, charDg.Kc2.Characteristics.Qn)),
            ConsPgCb4 = ConsPgCb(Qn1000(data.QcRcDgCb4, charDg.Kc2.Characteristics.Qn), data.ConsPgKc1,
                                    Qn1000(data.QcRcDgCb1, charDg.Kc1.Characteristics.Qn) + Qn1000(data.QcRcDgCb2, charDg.Kc1.Characteristics.Qn) +
                                    Qn1000(data.QcRcDgCb3, charDg.Kc2.Characteristics.Qn) + Qn1000(data.QcRcDgCb4, charDg.Kc2.Characteristics.Qn)),
            UdConsPgGru1 = data.ConsPgGru1 / (data.CbsConsFvSum / 0.4m),
            UdConsPgGru2 = data.ConsPgGru2 / (data.CbsConsFvSum / 0.6m),
         };

         return new ConsumptionDgPgDTO
         {
            Date = wetGas.Date,
            ConsDgCb1 = data2.ConsDgCb1,
            ConsDgCb2 = data2.ConsDgCb2,
            ConsDgCb3 = data2.ConsDgCb3,
            ConsDgCb4 = data2.ConsDgCb4,
            Kc1Sum = data2.Kc1Sum,
            ConsPgCb1 = data2.ConsPgCb1,
            ConsPgCb2 = data2.ConsPgCb2,
            ConsPgCb3 = data2.ConsPgCb3,
            ConsPgCb4 = data2.ConsPgCb4,
            ConsPgKc1 = data.ConsPgKc1,
            ConsPgGru1 = data.ConsPgGru1,
            ConsPgGru2 = data.ConsPgGru2,
            UdConsPgGru1 = data2.UdConsPgGru1,
            UdConsPgGru2 = data2.UdConsPgGru2,
            UdConsKgFvCb1 = UdConsDgFv(data2.ConsDgCb1, data2.ConsPgCb1, prod.Cb1ConsFv),
            UdConsKgFvCb2 = UdConsDgFv(data2.ConsDgCb2, data2.ConsPgCb2, prod.Cb2ConsFv),
            UdConsKgFvCb3 = UdConsDgFv(data2.ConsDgCb3, data2.ConsPgCb3, prod.Cb3ConsFv),
            UdConsKgFvCb4 = UdConsDgFv(data2.ConsDgCb4, data2.ConsPgCb4, prod.Cb4ConsFv),
            UdConsKgFvKc1 = UdConsDgFv(data2.Kc1Sum, data.ConsPgKc1, prod.Cb1ConsFv + prod.Cb2ConsFv + prod.Cb3ConsFv + prod.Cb4ConsFv),
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
