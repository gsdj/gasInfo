using DA.Entities.Characteristics;
using System.Collections.Generic;

namespace DA.Interfaces
{
   public interface ISteamRepository
   {
      SteamCharacteristics GetByTemp(decimal temp);
      IEnumerable<SteamCharacteristics> GetAllCharacteristics();
   }
}
