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
   public class CalcConsumptionDg : ICalculation<ConsumptionDgDTO>, ICalculations<ConsumptionDgDTO>, IQcRc, IConsGasQn<CalcConsumptionDg>
   {
      private Dictionary<int, SteamCharacteristicsDTO> _steam;
      public CalcConsumptionDg(ISteamCharacteristicsService st)
      {
         _steam = st.GetCharacteristics();
      }
      public IEnumerable<ConsumptionDgDTO> CalcEntities(EnumerableData data)
      {
         var Data = data as ConsumptionDgEnumData;
         var wetGas = Data.WetGas;
         var charDg = Data.CharacteristicsDg;
         var kip = Data.Kip;

         
         var d =
            from t1wetGas in wetGas
            join t2kip in kip on new { t1wetGas.Date } equals new { t2kip.Date }
            join t3charDg in charDg on new { t2kip.Date } equals new { t3charDg.Date }
            select new ConsumptionDgData
            {
               WetGas = t1wetGas,
               Kip = t2kip,
               CharacteristicsDg = t3charDg
            };

         List<ConsumptionDgDTO> consdgDTO = new List<ConsumptionDgDTO>(d.Count());

         foreach (var item in d)
         {
            consdgDTO.Add(CalcEntity(item));
         }
         return consdgDTO;
      }

      public ConsumptionDgDTO CalcEntity(Data data)
      {
         ConsumptionDgData Data = data as ConsumptionDgData;
         var kip = Data.Kip;
         var wetGas = Data.WetGas;
         var charDg = Data.CharacteristicsDg;

         var qcrc = new QcRcKc1
         {
            Cb1 = Calc(kip.Cb1.Consumption, wetGas.Cb1, kip.Cb1.Temperature, charDg.CharacteristicsAVG.Density),
            Cb2 = Calc(kip.Cb2.Consumption, wetGas.Cb2, kip.Cb2.Temperature, charDg.CharacteristicsAVG.Density),
            Cb3 = Calc(kip.Cb3.Consumption, wetGas.Cb3, kip.Cb3.Temperature, charDg.CharacteristicsAVG.Density),
            Cb4 = Calc(kip.Cb4.Consumption, wetGas.Cb4, kip.Cb4.Temperature, charDg.CharacteristicsAVG.Density),
         };

         var cons = new ConsumptionKc1<decimal>
         {
            Cb1 = Calc(qcrc.Cb1, charDg.CharacteristicsAVG.Qn),
            Cb2 = Calc(qcrc.Cb1, charDg.CharacteristicsAVG.Qn),
            Cb3 = Calc(qcrc.Cb1, charDg.CharacteristicsAVG.Qn),
            Cb4 = Calc(qcrc.Cb1, charDg.CharacteristicsAVG.Qn),
         };

         return new ConsumptionDgDTO
         {
            Date = wetGas.Date,
            QcRc = qcrc,
            ConsumptionDg = cons,
            ConsumptionDgMk = cons.Cb1 + cons.Cb2 + cons.Cb3 + cons.Cb4,
         };
      }

      public decimal Calc(decimal cons, decimal wetGas, decimal temp, decimal density, bool perHour = false)
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

      public decimal Calc(decimal qcrc, decimal qn)
      {
         if (qcrc == 0 || qn == 0)
            return 0;

         return Math.Round((qcrc * qn / 1000), 10);
      }
   }
}
