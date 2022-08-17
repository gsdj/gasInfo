using Business.DTO;
using System.Collections.Generic;

namespace Business.Interfaces.Services
{
   public interface ISteamCharacteristicsService
   {
      Dictionary<int, SteamCharacteristicsDTO> GetCharacteristics();
   }
}
