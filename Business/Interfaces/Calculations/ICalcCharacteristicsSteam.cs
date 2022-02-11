using Business.DTO.Characteristics;
using DataAccess.Entities.Characteristics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.Calculations
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
