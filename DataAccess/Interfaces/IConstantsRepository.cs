using DataAccess.Entities;
using DataAccess.Entities.Characteristics;
using System.Collections.Generic;

namespace DataAccess.Interfaces
{
   public interface IConstantsRepository
   {
      AllConstants GetAllConstants();
      SteamCharacteristics GetByTemp(decimal temp);
      IEnumerable<SteamCharacteristics> GetAllSteamCharacteristics();
      Constants GetConstants();
   }
}
