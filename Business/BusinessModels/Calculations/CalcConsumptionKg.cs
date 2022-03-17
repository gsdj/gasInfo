using Business.BusinessModels.DataForCalculations;
using Business.DTO;
using Business.DTO.Characteristics;
using Business.DTO.Consumption;
using Business.DTO.QcRc;
using Business.Interfaces;
using Business.Interfaces.BaseCalculations;
using Business.Interfaces.Calculations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.BusinessModels.Calculations
{
   public class CalcConsumptionKg : ICalculation<ConsumptionKgDTO>, ICalculations<ConsumptionKgDTO>, IQn, IQcRc
   {
      private Dictionary<int, SteamCharacteristicsDTO> _steam;
      private IConstantsAll _cAll;
      public CalcConsumptionKg(IConstantsAll cAll)
      {
         _cAll = cAll;
         _steam = _cAll.GetSteamCharacteristics();
      }

      public IEnumerable<ConsumptionKgDTO> CalcEntities(EnumerableData data)
      {
         var Data = data as ConsumptionKgEnumData;
         var wetGas = Data.WetGas;
         var charKg = Data.CharacteristicsKg;
         var kip = Data.Kip;
         
         var d =
            from t1wetGas in wetGas
            join t2kip in kip on new { t1wetGas.Date } equals new { t2kip.Date }
            join t3charKg in charKg on new { t2kip.Date } equals new { t3charKg.Date }
            select new ConsumptionKgData
            {
               WetGas = t1wetGas,
               Kip = t2kip,
               CharacteristicsKg = t3charKg,
            };

         List<ConsumptionKgDTO> conskgDTO = new List<ConsumptionKgDTO>(d.Count());
         foreach (var item in d)
         {
            conskgDTO.Add(CalcEntity(item));
         }
         return conskgDTO;
      }

      public ConsumptionKgDTO CalcEntity(Data data)
      {
         ConsumptionKgData Data = data as ConsumptionKgData;
         var kip = Data.Kip;
         var wetGas = Data.WetGas;
         var charKg = Data.CharacteristicsKg;

         var qcrcAll = new
         {
            QcRcCb = new QcRcKc2
            {
               Cb5 = QcRc(kip.Cb5.Consumption, wetGas.Cb5, kip.Cb5.TempBeforeHeating, charKg.Kc1.Characteristics.Density, true),
               Cb6 = QcRc(kip.Cb6.Consumption, wetGas.Cb6, kip.Cb6.TempBeforeHeating, charKg.Kc1.Characteristics.Density, true),
               Cb7 =
               {
                  Ms = QcRc(kip.Cb7.ConsumptionMs, wetGas.Cb7, kip.Cb7.TempBeforeHeating, charKg.Kc2.Characteristics.Density),
                  Ks = QcRc(kip.Cb7.ConsumptionKs, wetGas.Cb7, kip.Cb7.TempBeforeHeating, charKg.Kc2.Characteristics.Density),
               },
               Cb8 =
               {
                  Ms = QcRc(kip.Cb8.ConsumptionMs, wetGas.Cb8, kip.Cb8.TempBeforeHeating, charKg.Kc2.Characteristics.Density),
                  Ks = QcRc(kip.Cb8.ConsumptionKs, wetGas.Cb8, kip.Cb8.TempBeforeHeating, charKg.Kc2.Characteristics.Density),
               },
            },
            QcRcCpsPpk = new QcRcCpsPpk
            {
               Pko =
               {
                  Ms = QcRc(kip.Pkc.ConsumptionMs, wetGas.Pkc, kip.Pkc.Temperature, charKg.Kc1.Characteristics.Density),
                  Ks = QcRc(kip.Pkc.ConsumptionKs, wetGas.Pkc, kip.Pkc.Temperature, charKg.Kc1.Characteristics.Density),
               },
               Uvtp = QcRc(kip.Uvtp.Consumption, wetGas.Uvtp, kip.Uvtp.Temperature, charKg.Kc1.Characteristics.Density),
               Spo = QcRc(kip.Spo.Consumption, wetGas.Spo, kip.Spo.Temperature, charKg.Kc1.Characteristics.Density),
            },
            QcRcGsuf = QcRc(kip.Gsuf45.Consumption, wetGas.Gsuf, kip.Gsuf45.Temperature, charKg.Kc1.Characteristics.Density),
         };

         var consCb = new ConsumptionKc2<decimal>
         {
            Cb5 = Qn(qcrcAll.QcRcCb.Cb5, charKg.Kc1.Characteristics.Qn),
            Cb6 = Qn(qcrcAll.QcRcCb.Cb6, charKg.Kc1.Characteristics.Qn),
            Cb7 = Qn(qcrcAll.QcRcCb.Cb7.Value, charKg.Kc2.Characteristics.Qn),
            Cb8 = Qn(qcrcAll.QcRcCb.Cb8.Value, charKg.Kc2.Characteristics.Qn),
         };

         var consCpsPpk = new ConsumptionCpsPpk
         {
            Pko = Qn(qcrcAll.QcRcCpsPpk.Pko.Value + qcrcAll.QcRcCpsPpk.Uvtp, charKg.Kc1.Characteristics.Qn),
            Spo = Qn(qcrcAll.QcRcCpsPpk.Spo, charKg.Kc1.Characteristics.Qn),
         };

         return new ConsumptionKgDTO
         {
            Date = wetGas.Date,
            QcRcCb = qcrcAll.QcRcCb,
            QcRcCpsPpk = qcrcAll.QcRcCpsPpk,
            QcRcGsuf = qcrcAll.QcRcGsuf,
            ConsumptionCb = consCb,
            ConsumptionKc2Sum = consCb.Cb5 + consCb.Cb6 + consCb.Cb7 + consCb.Cb8,
            PkoSum = qcrcAll.QcRcCpsPpk.Pko.Value + qcrcAll.QcRcCpsPpk.Uvtp,
            ConsumptionCpsPpk = consCpsPpk,
            ConsumptionCpsPpkSum = Qn(qcrcAll.QcRcCpsPpk.Pko.Value + qcrcAll.QcRcCpsPpk.Uvtp, charKg.Kc1.Characteristics.Qn) + Qn(qcrcAll.QcRcCpsPpk.Spo, charKg.Kc1.Characteristics.Qn),
            ConsumptionMkSum = consCb.Cb5 + consCb.Cb6 + consCb.Cb7 + consCb.Cb8 + consCpsPpk.Pko + consCpsPpk.Spo,
            ConsumptionGsuf = Qn(qcrcAll.QcRcGsuf, charKg.Kc1.Characteristics.Qn),
            ConsumptionMkGsufSum = consCb.Cb5 + consCb.Cb6 + consCb.Cb7 + consCb.Cb8 + consCpsPpk.Pko + consCpsPpk.Spo +
                                    Qn(qcrcAll.QcRcGsuf, charKg.Kc1.Characteristics.Qn),
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
