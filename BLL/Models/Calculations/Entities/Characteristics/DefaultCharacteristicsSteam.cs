using BLL.DTO;
using BLL.Interfaces.Calculations.Characteristics;
using DA.Entities.Characteristics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Calculations.Entities.Characteristics
{
   public class DefaultCharacteristicsSteam : ICalcCharacteristicsSteam
   {
      public Dictionary<int,SteamCharacteristicsDTO> CalcEntities(IEnumerable<SteamCharacteristics> stCs)
      {
         Dictionary<int, SteamCharacteristicsDTO> stDict = new Dictionary<int, SteamCharacteristicsDTO>(stCs.Count());
         foreach (var item in stCs)
         {
            stDict.Add(item.Temp, CalcEntity(item));
         }
         return stDict;
      }

      public SteamCharacteristicsDTO CalcEntity(SteamCharacteristics stC)
      {
         return new SteamCharacteristicsDTO
         {
            Temp = stC.Temp,
            Pmm = stC.Pmm,
            Pgm = stC.Pgm,
            Ptopp = stC.Ptopp,
            PPa = PPa(stC.Pmm),
            PKg = PKg(stC.Pgm),
            Fkg = FKg(stC.Ptopp),
            Rh = Rh(FKg(stC.Ptopp), PKg(stC.Pgm)),
         };
      }

      public decimal FKg(decimal ptopp)
      {
         return Math.Round((ptopp / 1000), 10);
      }

      public decimal PKg(decimal pgm)
      {
         return Math.Round((pgm / 1000), 10);
      }

      public decimal PPa(decimal pmm)
      {
         return Math.Round((pmm * 133.3224m), 10);
      }

      public decimal Rh(decimal fkg, decimal pkg)
      {
         return Math.Round(fkg / pkg, 10);
      }
   }
}
