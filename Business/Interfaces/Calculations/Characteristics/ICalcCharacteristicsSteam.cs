using Business.DTO;
using DataAccess.Entities.Characteristics;
using System.Collections.Generic;

namespace Business.Interfaces.Calculations.Characteristics
{
   public interface ICalcCharacteristicsSteam
   {
      Dictionary<int,SteamCharacteristicsDTO> CalcEntities(IEnumerable<SteamCharacteristics> stCs);
      SteamCharacteristicsDTO CalcEntity(SteamCharacteristics stC);
      decimal PPa(decimal pmm);
      decimal PKg(decimal pgm);
      decimal FKg(decimal ptopp);
      decimal Rh(decimal fkg, decimal pkg);
   }
}
