using DataAccess.Entities;
using DataAccess.Entities.Characteristics;
using System.Collections.Generic;

namespace DataAccess.Interfaces
{
   public interface ISteamRepository
   {
      SteamCharacteristics GetByTemp(decimal temp);
      IEnumerable<SteamCharacteristics> GetAllCharacteristics();
   }
}
