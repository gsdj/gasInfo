using Business.DTO;
using Business.DTO.Characteristics.CharacteristicsGas;
using Business.DTO.InfoSheet;
using Business.Interfaces.Calculations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessModels.Calculations
{
   public class CalcInfoSheet : ICalcInfoSheet
   {
      public InfoSheetDTO CalcInfo(InfoSheetData data)
      {
         var charGas = new CharacteristicsKgDg
         {
            CharacteristicsDG =
               {
                  Qn = Math.Round(data.CharacteristicsDg.CharacteristicsAVG.Qn, 2),
                  Density = Math.Round(data.CharacteristicsDg.CharacteristicsAVG.Density, 2),
               },
            CharacteristicsKGKc1 =
               {
                  Qn = Math.Round(data.CharacteristicsKg.Kc1.Characteristics.Qn, 2),
                  Density = Math.Round(data.CharacteristicsKg.Kc1.Characteristics.Density, 2),
               },
            CharacteristicsKGKc2 =
               {
                  Qn = Math.Round(data.CharacteristicsKg.Kc2.Characteristics.Qn, 2),
                  Density = Math.Round(data.CharacteristicsKg.Kc2.Characteristics.Density, 2),
               }
         };

         return new InfoSheetDTO
         {
            CharacteristicsGas = charGas,
         };
      }
   }
}
