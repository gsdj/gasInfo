using Business.BusinessModels.DataForCalculations;
using Business.DTO;
using Business.DTO.Characteristics;
using Business.DTO.Consumption;
using Business.DTO.QcRc;
using Business.Interfaces.Calculations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessModels.Calculations
{
   public class CalcConsumptionDg : ICalculation<ConsumptionDgDTO>// ICalcConsumptionDg
   {
      private Dictionary<int, SteamCharacteristicsDTO> _steam;
      //public IEnumerable<ConsumptionDgDTO> CalcEntities(IEnumerable<DensityDTO> wetGas, IEnumerable<DevicesKipDTO> kips, 
      //   IEnumerable<CharacteristicsDgDTO> charDgs, Dictionary<int, SteamCharacteristicsDTO> steam)
      //{
      //   _steam = steam;
      //   List<ConsumptionDgDTO> consdgDTO = new List<ConsumptionDgDTO>(wetGas.Count());
      //   var data =
      //      from t1wetGas in wetGas
      //      join t2kip in kips on new { t1wetGas.Date } equals new { t2kip.Date }
      //      join t3charDg in charDgs on new { t2kip.Date } equals new { t3charDg.Date }
      //      select new
      //      {
      //         WetGas = t1wetGas,
      //         Kip = t2kip,
      //         CharDg = t3charDg
      //      };
      //   foreach (var item in data)
      //   {
      //      consdgDTO.Add(CalcEntity(item.WetGas, item.Kip, item.CharDg));
      //   }
      //   return consdgDTO;
      //}

      //public ConsumptionDgDTO CalcEntity(DensityDTO wetGas, DevicesKipDTO kip, CharacteristicsDgDTO charDg)
      //{
      //   var qcrc = new QcRcKc1
      //   {
      //      Cb1 = QcRc(kip.Cb1.Consumption, wetGas.Cb1, kip.Cb1.Temperature, charDg.CharacteristicsAVG.Density),
      //      Cb2 = QcRc(kip.Cb2.Consumption, wetGas.Cb2, kip.Cb2.Temperature, charDg.CharacteristicsAVG.Density),
      //      Cb3 = QcRc(kip.Cb3.Consumption, wetGas.Cb3, kip.Cb3.Temperature, charDg.CharacteristicsAVG.Density),
      //      Cb4 = QcRc(kip.Cb4.Consumption, wetGas.Cb4, kip.Cb4.Temperature, charDg.CharacteristicsAVG.Density),
      //   };

      //   var cons = new ConsumptionKc1<decimal>
      //   {
      //      Cb1 = Qn1000(qcrc.Cb1, charDg.CharacteristicsAVG.Qn),
      //      Cb2 = Qn1000(qcrc.Cb1, charDg.CharacteristicsAVG.Qn),
      //      Cb3 = Qn1000(qcrc.Cb1, charDg.CharacteristicsAVG.Qn),
      //      Cb4 = Qn1000(qcrc.Cb1, charDg.CharacteristicsAVG.Qn),
      //   };

      //   return new ConsumptionDgDTO
      //   {
      //      Date = wetGas.Date,
      //      QcRc = qcrc,
      //      ConsumptionDg = cons,
      //      ConsumptionDgMk = cons.Cb1 + cons.Cb2 + cons.Cb3 + cons.Cb4,
      //   };
      //}

      public ConsumptionDgDTO CalcEntity(Data data)
      {
         ConsumptionDgData Data = data as ConsumptionDgData;
         var kip = Data.Kip;
         var wetGas = Data.WetGas;
         var charDg = Data.CharacteristicsDg;
         _steam = Data.Steam;

         var qcrc = new QcRcKc1
         {
            Cb1 = QcRc(kip.Cb1.Consumption, wetGas.Cb1, kip.Cb1.Temperature, charDg.CharacteristicsAVG.Density),
            Cb2 = QcRc(kip.Cb2.Consumption, wetGas.Cb2, kip.Cb2.Temperature, charDg.CharacteristicsAVG.Density),
            Cb3 = QcRc(kip.Cb3.Consumption, wetGas.Cb3, kip.Cb3.Temperature, charDg.CharacteristicsAVG.Density),
            Cb4 = QcRc(kip.Cb4.Consumption, wetGas.Cb4, kip.Cb4.Temperature, charDg.CharacteristicsAVG.Density),
         };

         var cons = new ConsumptionKc1<decimal>
         {
            Cb1 = Qn1000(qcrc.Cb1, charDg.CharacteristicsAVG.Qn),
            Cb2 = Qn1000(qcrc.Cb1, charDg.CharacteristicsAVG.Qn),
            Cb3 = Qn1000(qcrc.Cb1, charDg.CharacteristicsAVG.Qn),
            Cb4 = Qn1000(qcrc.Cb1, charDg.CharacteristicsAVG.Qn),
         };

         return new ConsumptionDgDTO
         {
            Date = wetGas.Date,
            QcRc = qcrc,
            ConsumptionDg = cons,
            ConsumptionDgMk = cons.Cb1 + cons.Cb2 + cons.Cb3 + cons.Cb4,
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

      public decimal Qn1000(decimal qcrc, decimal qn)
      {
         if (qcrc == 0 || qn == 0)
            return 0;

         return Math.Round((qcrc * qn / 1000), 10);
      }
   }
}
