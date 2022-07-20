using Business.DTO;
using System.Collections.Generic;

namespace Business.Interfaces
{
   public interface ISteamCharacteristicsService
   {
      Dictionary<int, SteamCharacteristicsDTO> GetCharacteristics();
   }
}
