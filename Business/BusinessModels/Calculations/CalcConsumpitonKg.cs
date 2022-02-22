using Business.DTO;
using Business.DTO.Characteristics;
using Business.Interfaces.Calculations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessModels.Calculations
{
   public class CalcConsumpitonKg : ICalcConsumptionKg
   {
      private Dictionary<int, SteamCharacteristicsDTO> _steam;
      public IEnumerable<ConsumptionKgDTO> CalcEntities(IEnumerable<DensityDTO> wetGas, IEnumerable<DevicesKipDTO> kips, 
         IEnumerable<CharacteristicsKgDTO> charKgs, Dictionary<int, SteamCharacteristicsDTO> steam)
      {
         _steam = steam;
         List<ConsumptionKgDTO> conskgDTO = new List<ConsumptionKgDTO>(wetGas.Count());
         var data =
            from t1wetGas in wetGas
            join t2kip in kips on new { t1wetGas.Date } equals new { t2kip.Date }
            join t3charKg in charKgs on new { t2kip.Date } equals new { t3charKg.Date }
            select new
            {
               WetGas = t1wetGas,
               Kip = t2kip,
               CharKg = t3charKg
            };
         foreach (var item in data)
         {
            conskgDTO.Add(CalcEntity(item.WetGas, item.Kip, item.CharKg));
         }
         return conskgDTO;
      }

      public ConsumptionKgDTO CalcEntity(DensityDTO wetGas, DevicesKipDTO kip, CharacteristicsKgDTO charKg)
      {
         var data = new
         {
            Date = wetGas.Date,
            QcRcCb5 = QcRc(kip.Cb5.Consumption, wetGas.Cb5, kip.Cb5.TempBeforeHeating, charKg.Kc1.Characteristics.Density, true),
            QcRcCb6 = QcRc(kip.Cb6.Consumption, wetGas.Cb6, kip.Cb6.TempBeforeHeating, charKg.Kc1.Characteristics.Density, true),
            QcRcCb7Ms = QcRc(kip.Cb7.ConsumptionMs, wetGas.Cb7, kip.Cb7.TempBeforeHeating, charKg.Kc2.Characteristics.Density),
            QcRcCb7Ks = QcRc(kip.Cb7.ConsumptionKs, wetGas.Cb7, kip.Cb7.TempBeforeHeating, charKg.Kc2.Characteristics.Density),
            QcRcCb8Ms = QcRc(kip.Cb8.ConsumptionMs, wetGas.Cb8, kip.Cb8.TempBeforeHeating, charKg.Kc2.Characteristics.Density),
            QcRcCb8Ks = QcRc(kip.Cb8.ConsumptionKs, wetGas.Cb8, kip.Cb8.TempBeforeHeating, charKg.Kc2.Characteristics.Density),
            QcRcPkcMs = QcRc(kip.Pkc.ConsumptionMs, wetGas.Pkc, kip.Pkc.Temperature, charKg.Kc1.Characteristics.Density),
            QcRcPkcKs = QcRc(kip.Pkc.ConsumptionKs, wetGas.Pkc, kip.Pkc.Temperature, charKg.Kc1.Characteristics.Density),
            QcRcUvtp = QcRc(kip.Uvtp.Consumption, wetGas.Uvtp, kip.Uvtp.Temperature, charKg.Kc1.Characteristics.Density),
            QcRcSpo = QcRc(kip.Spo.Consumption, wetGas.Spo, kip.Spo.Temperature, charKg.Kc1.Characteristics.Density),
            QcRcGsuf = QcRc(kip.Gsuf45.Consumption, wetGas.Gsuf, kip.Gsuf45.Temperature, charKg.Kc1.Characteristics.Density),
         };
         return new ConsumptionKgDTO
         {
            Date = data.Date,
            QcRcCb5 = data.QcRcCb5,
            QcRcCb6 = data.QcRcCb6,
            QcRcCb7Ms = data.QcRcCb7Ms,
            QcRcCb7Ks = data.QcRcCb7Ks,
            QcRcCb8Ms = data.QcRcCb8Ms,
            QcRcCb8Ks = data.QcRcCb8Ks,
            QcRcPkcMs = data.QcRcPkcMs,
            QcRcPkcKs = data.QcRcPkcKs,
            QcRcUvtp = data.QcRcUvtp,
            QcRcSpo = data.QcRcSpo,
            QcRcGsuf = data.QcRcGsuf,
            Cb54000 = Qn4000(data.QcRcCb5, charKg.Kc1.Characteristics.Qn),
            Cb64000 = Qn4000(data.QcRcCb6, charKg.Kc1.Characteristics.Qn),
            QcRcCb7 = (data.QcRcCb7Ks + data.QcRcCb7Ms) * 24,
            Cb74000 = Qn4000((data.QcRcCb7Ks + data.QcRcCb7Ms) * 24, charKg.Kc2.Characteristics.Qn),
            QcRcCb8 = (data.QcRcCb8Ks + data.QcRcCb8Ms) * 24,
            Cb84000 = Qn4000((data.QcRcCb8Ks + data.QcRcCb8Ms) * 24, charKg.Kc2.Characteristics.Qn),
            Kc2Sum = Qn4000(data.QcRcCb5, charKg.Kc1.Characteristics.Qn) + Qn4000(data.QcRcCb6, charKg.Kc1.Characteristics.Qn) + Qn4000((data.QcRcCb7Ks + data.QcRcCb7Ms) * 24, charKg.Kc2.Characteristics.Qn) + Qn4000((data.QcRcCb8Ks + data.QcRcCb8Ms) * 24, charKg.Kc2.Characteristics.Qn),
            PkoSum = data.QcRcPkcKs + data.QcRcPkcMs + data.QcRcUvtp,
            Pko4000 = Qn4000(data.QcRcPkcKs + data.QcRcPkcMs + data.QcRcUvtp, charKg.Kc1.Characteristics.Qn),
            Spo4000 = Qn4000(data.QcRcSpo, charKg.Kc1.Characteristics.Qn),
            CpsppkSum4000 = Qn4000(data.QcRcPkcKs + data.QcRcPkcMs + data.QcRcUvtp, charKg.Kc1.Characteristics.Qn) + Qn4000(data.QcRcSpo, charKg.Kc1.Characteristics.Qn),
            MkSum4000 = Qn4000(data.QcRcCb5, charKg.Kc1.Characteristics.Qn) + Qn4000(data.QcRcCb6, charKg.Kc1.Characteristics.Qn) +
                            Qn4000((data.QcRcCb7Ks + data.QcRcCb7Ms) * 24, charKg.Kc2.Characteristics.Qn) +
                            Qn4000((data.QcRcCb8Ks + data.QcRcCb8Ms) * 24, charKg.Kc2.Characteristics.Qn) +
                            Qn4000(data.QcRcPkcKs + data.QcRcPkcMs + data.QcRcUvtp, charKg.Kc1.Characteristics.Qn) + Qn4000(data.QcRcSpo, charKg.Kc1.Characteristics.Qn),
            Gsuf4000 = Qn4000(data.QcRcGsuf, charKg.Kc1.Characteristics.Qn),
            MkGsufSum4000 = Qn4000(data.QcRcCb5, charKg.Kc1.Characteristics.Qn) + Qn4000(data.QcRcCb6, charKg.Kc1.Characteristics.Qn) +
                            Qn4000((data.QcRcCb7Ks + data.QcRcCb7Ms) * 24, charKg.Kc2.Characteristics.Qn) +
                            Qn4000((data.QcRcCb8Ks + data.QcRcCb8Ms) * 24, charKg.Kc2.Characteristics.Qn) +
                            Qn4000(data.QcRcPkcKs + data.QcRcPkcMs + data.QcRcUvtp, charKg.Kc1.Characteristics.Qn) +
                            Qn4000(data.QcRcSpo, charKg.Kc1.Characteristics.Qn) + Qn4000(data.QcRcGsuf, charKg.Kc1.Characteristics.Qn),
         };
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

      public decimal Qn4000(decimal qcrc, decimal qn)
      {
         if (qcrc == 0 || qn == 0)
            return 0;

         return Math.Round((qcrc * qn / 4000), 10);
      }
   }
}
