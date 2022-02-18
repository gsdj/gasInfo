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
   public class CalcOutputKG : ICalcOutputKg
   {
      private Dictionary<int, SteamCharacteristicsDTO> _steam;
      public IEnumerable<OutputKgDTO> CalcEntities(IEnumerable<DensityDTO> wetGas, IEnumerable<ProductionDTO> prod, 
         IEnumerable<DevicesKipDTO> kips, IEnumerable<CharacteristicsKgDTO> charKgs, Dictionary<int, SteamCharacteristicsDTO> steam)
      {
         _steam = steam;
         List<OutputKgDTO> kgDTO = new List<OutputKgDTO>(wetGas.Count());
         var data =
            from t1wetGas in wetGas
            join t2prod in prod on new { t1wetGas.Date } equals new { t2prod.Date }
            join t3kip in kips on new { t2prod.Date } equals new { t3kip.Date }
            join t4charKg in charKgs on new { t3kip.Date } equals new { t4charKg.Date }
            select new
            {
               WetGas = t1wetGas,
               Prod = t2prod,
               Kip = t3kip,
               CharKg = t4charKg
            };
         foreach (var item in data)
         {
            kgDTO.Add(CalcEntity(item.WetGas, item.Prod, item.Kip, item.CharKg));
         }
         return kgDTO;
      }

      public OutputKgDTO CalcEntity(DensityDTO wetGas, ProductionDTO prod, DevicesKipDTO kip, CharacteristicsKgDTO charKg)
      {
         return new OutputKgDTO
         {
            Date = wetGas.Date,
            QcRcCu1 = QcRc(kip.Cu1.Consumption, wetGas.Cu1, kip.Cu1.Temperature, charKg.Kc1.Density),
            QcRcCu2 = QcRc(kip.Cu2.Consumption, wetGas.Cu2, kip.Cu2.Temperature, charKg.Kc2.Density),
            Cu14000 = Qn4000(QcRc(kip.Cu1.Consumption, wetGas.Cu1, kip.Cu1.Temperature, charKg.Kc1.Density), charKg.Kc1.Qn),
            Cu24000 = Qn4000(QcRc(kip.Cu2.Consumption, wetGas.Cu2, kip.Cu2.Temperature, charKg.Kc2.Density), charKg.Kc1.Qn),
            Cu1Cb16 = Qn4000(QcRc(kip.Cu1.Consumption, wetGas.Cu1, kip.Cu1.Temperature, charKg.Kc1.Density), charKg.Kc1.Qn) / prod.Cb16Sv,
            Cu2Cb78 = Qn4000(QcRc(kip.Cu2.Consumption, wetGas.Cu2, kip.Cu2.Temperature, charKg.Kc2.Density), charKg.Kc1.Qn) / prod.Cb78Sv,
            PrMk = QcRc(kip.Cu1.Consumption, wetGas.Cu1, kip.Cu1.Temperature, charKg.Kc1.Density) + 
                     QcRc(kip.Cu2.Consumption, wetGas.Cu2, kip.Cu2.Temperature, charKg.Kc2.Density),
            PrMk4000 = Qn4000(QcRc(kip.Cu1.Consumption, wetGas.Cu1, kip.Cu1.Temperature, charKg.Kc1.Density), charKg.Kc1.Qn) +
                        Qn4000(QcRc(kip.Cu2.Consumption, wetGas.Cu2, kip.Cu2.Temperature, charKg.Kc2.Density), charKg.Kc1.Qn),
            OutCgSh = (Qn4000(QcRc(kip.Cu1.Consumption, wetGas.Cu1, kip.Cu1.Temperature, charKg.Kc1.Density), charKg.Kc1.Qn) +
                        Qn4000(QcRc(kip.Cu2.Consumption, wetGas.Cu2, kip.Cu2.Temperature, charKg.Kc2.Density), charKg.Kc1.Qn)) / (prod.Cb16Sv + prod.Cb78Sv)
         };
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

      public decimal Qn4000(decimal qcrc, decimal qn)
      {
         if (qcrc == 0 || qn == 0)
            return 0;

         return Math.Round((qcrc * qn / 4000), 10);
      }
   }
}
