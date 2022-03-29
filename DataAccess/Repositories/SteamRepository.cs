using DataAccess.Entities.Characteristics;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repositories
{
   public class SteamRepository : ISteamRepository
   {
      private IJsonFileReader<SteamCharacteristics> reader;
      private IEnumerable<SteamCharacteristics> steam;
      public SteamRepository(IJsonFileReader<SteamCharacteristics> r)
      {
         reader = r;
         steam = reader.Read();
      }
      public IEnumerable<SteamCharacteristics> GetAllCharacteristics()
      {
         return steam;
      }

      public SteamCharacteristics GetByTemp(decimal temp)
      {
         int tempRounded = Convert.ToInt32(Math.Round(temp, MidpointRounding.ToEven));
         return steam.FirstOrDefault(p => p.Temp == tempRounded);
      }
   }
}
