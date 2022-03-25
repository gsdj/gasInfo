using Business.BusinessModels.DataForCalculations;
using Business.DTO;
using Business.DTO.Characteristics;
using Business.Interfaces;
using Business.Interfaces.BaseCalculations;
using Business.Interfaces.Calculations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.BusinessModels.Calculations
{
   public class CalcOutputKG : ICalculation<OutputKgDTO>, ICalculations<OutputKgDTO>, IQn1, IQcRc
   {
      private Dictionary<int, SteamCharacteristicsDTO> _steam;
      private IConstantsAll _cAll;
      public CalcOutputKG(IConstantsAll cAll)
      {
         _cAll = cAll;
         _steam = _cAll.GetSteamCharacteristics();
      }

      public IEnumerable<OutputKgDTO> CalcEntities(EnumerableData data)
      {
         var Data = data as OutputKgEnumData;
         var wetGas = Data.WetGas;
         var prod = Data.Production;
         var kip = Data.Kip;
         var charKg = Data.CharacteristicsKg;

        
         var d =
            from t1wetGas in wetGas
            join t2prod in prod on new { t1wetGas.Date } equals new { t2prod.Date }
            join t3kip in kip on new { t2prod.Date } equals new { t3kip.Date }
            join t4charKg in charKg on new { t3kip.Date } equals new { t4charKg.Date }
            select new OutputKgData
            {
               WetGas = t1wetGas,
               Production = t2prod,
               Kip = t3kip,
               CharacteristicsKg = t4charKg
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
         var wetGas = Data.WetGas;
         var kip = Data.Kip;
         var charKg = Data.CharacteristicsKg;
         var prod = Data.Production;

         return new OutputKgDTO
         {
            Date = wetGas.Date,
            QcRcCu1 = QcRc(kip.Cu1.Consumption, wetGas.Cu1, kip.Cu1.Temperature, charKg.Kc1.Characteristics.Density),
            QcRcCu2 = QcRc(kip.Cu2.Consumption, wetGas.Cu2, kip.Cu2.Temperature, charKg.Kc2.Characteristics.Density),
            Cu14000 = Qn(QcRc(kip.Cu1.Consumption, wetGas.Cu1, kip.Cu1.Temperature, charKg.Kc1.Characteristics.Density), charKg.Kc1.Characteristics.Qn),
            Cu24000 = Qn(QcRc(kip.Cu2.Consumption, wetGas.Cu2, kip.Cu2.Temperature, charKg.Kc2.Characteristics.Density), charKg.Kc1.Characteristics.Qn),
            Cu1Cb16 = Qn(QcRc(kip.Cu1.Consumption, wetGas.Cu1, kip.Cu1.Temperature, charKg.Kc1.Characteristics.Density), charKg.Kc1.Characteristics.Qn) / prod.Cb16Sv,
            Cu2Cb78 = Qn(QcRc(kip.Cu2.Consumption, wetGas.Cu2, kip.Cu2.Temperature, charKg.Kc2.Characteristics.Density), charKg.Kc1.Characteristics.Qn) / prod.Cb78Sv,
            PrMk = QcRc(kip.Cu1.Consumption, wetGas.Cu1, kip.Cu1.Temperature, charKg.Kc1.Characteristics.Density) +
            QcRc(kip.Cu2.Consumption, wetGas.Cu2, kip.Cu2.Temperature, charKg.Kc2.Characteristics.Density),
            PrMk4000 = Qn(QcRc(kip.Cu1.Consumption, wetGas.Cu1, kip.Cu1.Temperature, charKg.Kc1.Characteristics.Density), charKg.Kc1.Characteristics.Qn) +
               Qn(QcRc(kip.Cu2.Consumption, wetGas.Cu2, kip.Cu2.Temperature, charKg.Kc2.Characteristics.Density), charKg.Kc1.Characteristics.Qn),
            OutCgSh = (Qn(QcRc(kip.Cu1.Consumption, wetGas.Cu1, kip.Cu1.Temperature, charKg.Kc1.Characteristics.Density), charKg.Kc1.Characteristics.Qn) +
               Qn(QcRc(kip.Cu2.Consumption, wetGas.Cu2, kip.Cu2.Temperature, charKg.Kc2.Characteristics.Density), charKg.Kc1.Characteristics.Qn)) / (prod.Cb16Sv + prod.Cb78Sv)
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

      public decimal Qn(decimal qcrc, decimal qn)
      {
         if (qcrc == 0 || qn == 0)
            return 0;

         return Math.Round((qcrc * qn / 4000), 10);
      }
   }
}
