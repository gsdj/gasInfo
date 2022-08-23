using BLL.DTO;
using BLL.Interfaces.Calculations.Characteristics;
using BLL.Interfaces.Services;
using DA.Interfaces;
using System.Collections.Generic;

namespace BLL.Services
{
   public class SteamCharacteristicsService : ISteamCharacteristicsService
   {
      private readonly Dictionary<int, SteamCharacteristicsDTO> _steam;
      private ISteamRepository steamRep;
      private ICalcCharacteristicsSteam calcSteam;
      public SteamCharacteristicsService(ICalcCharacteristicsSteam st, ISteamRepository cjr)
      {
         steamRep = cjr;
         calcSteam = st;
         _steam = calcSteam.CalcEntities(steamRep.GetAllCharacteristics());
      }
      public Dictionary<int,SteamCharacteristicsDTO> GetCharacteristics()
      {
         return _steam;
      }
   }
}
