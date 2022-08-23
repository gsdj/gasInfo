using BLL.DTO;
using System.Collections.Generic;

namespace BLL.Interfaces.Services
{
   public interface ISteamCharacteristicsService
   {
      Dictionary<int, SteamCharacteristicsDTO> GetCharacteristics();
   }
}
