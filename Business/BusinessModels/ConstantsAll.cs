using Business.DTO.Characteristics;
using Business.Interfaces;
using Business.Interfaces.Calculations;
using DataAccess.Entities;
using DataAccess.Interfaces;
using System.Collections.Generic;

namespace Business.BusinessModels
{
   public class ConstantsAll : IConstantsAll
   {
      private Dictionary<int, SteamCharacteristicsDTO> _steam;
      private Constants _constants;
      private IConstantsRepository constRep;
      private ICalcCharacteristicsSteam calcSteam;
      public ConstantsAll(ICalcCharacteristicsSteam st, IConstantsRepository cjr)
      {
         constRep = cjr;
         calcSteam = st;
         _constants = constRep.GetConstants();
         _steam = calcSteam.CalcEntities(constRep.GetAllSteamCharacteristics());
      }
      public Dictionary<int,SteamCharacteristicsDTO> GetSteamCharacteristics()
      {
         return _steam;
      }
      public Constants GetConstants()
      {
         return _constants;
      }
   }
}
