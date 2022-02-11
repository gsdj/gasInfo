using DataAccess.Entities.Characteristics;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
   public class SteamJsonReader
   {
      private string _path;
      private List<SteamCharacteristics> stList;
      public SteamJsonReader(string path)
      {
         _path = path;
      }
      private void Read(string path)
      {
         using (StreamReader r = new StreamReader(path))
         {
            string json = r.ReadToEnd();
            stList = new List<SteamCharacteristics>();
            int i = 1;
            foreach (var item in JsonConvert.DeserializeObject<IEnumerable<SteamCharacteristics>>(json))
            {
               stList.Add(new SteamCharacteristics
               {
                  Id = i,
                  Pgm = item.Pgm,
                  Pmm = item.Pmm,
                  Temp = item.Temp,
                  Ptopp = item.Ptopp,
               });
               i++;
            }
         }
      }
      public List<SteamCharacteristics> GetAllSteamCharacteristics()
      {
         if (stList == null)
         {
            Read(_path);
         }
         return stList;
      }
   }
}
