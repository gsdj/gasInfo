using DataAccess.Entities;
using DataAccess.Entities.Characteristics;
using DataAccess.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
   public class ConstantsJsonReader : IConstantsRepository
   {
      private string _path;
      private AllConstants _all;
      public ConstantsJsonReader(string path)
      {
         _path = path;
      }
      private void Read(string path)
      {
         using (StreamReader r = new StreamReader(path))
         {
            string json = r.ReadToEnd();
            var res = JsonConvert.DeserializeObject<AllConstants>(json);
            _all = res;
         }
      }

      public SteamCharacteristics GetByTemp(decimal temp)
      {
         int tempRounded = Convert.ToInt32(Math.Round(temp, MidpointRounding.ToEven));
         return _all.SteamCharacteristics.FirstOrDefault(p => p.Temp == tempRounded);
      }

      public IEnumerable<SteamCharacteristics> GetAllSteamCharacteristics()
      {
         if (_all == null)
         {
            Read(_path);
         }
         return _all.SteamCharacteristics;
      }

      public Constants GetConstants()
      {
         if (_all == null)
         {
            Read(_path);
         }
         return _all.Constants;
      }

      public AllConstants GetAllConstants()
      {
         if (_all == null)
         {
            Read(_path);
         }
         return _all;
      }
   }

   public class AllConstants
   {
      public Constants Constants { get; set; }
      public IEnumerable<SteamCharacteristics> SteamCharacteristics { get; set; }
   }
}
