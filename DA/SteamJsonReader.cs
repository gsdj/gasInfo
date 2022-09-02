using DA.Entities.Characteristics;
using DA.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace DA
{
   public class SteamJsonReader : IJsonFileReader<SteamCharacteristics>
   {
      private string _path;
      public SteamJsonReader(string path)
      {
         _path = path;
      }
      private IEnumerable<SteamCharacteristics> ReadSteamJsonFile(string path)
      {
         try
         {
            using (StreamReader r = new StreamReader(path))
            {
               string json = r.ReadToEnd();
               var res = JsonConvert.DeserializeObject<IEnumerable<SteamCharacteristics>>(json);
               return res;
            }
         }
         catch
         {
            throw new FileLoadException();
         }
      }
      public IEnumerable<SteamCharacteristics> Read(string path)
      {
         return ReadSteamJsonFile(path);
      }
      public IEnumerable<SteamCharacteristics> Read()
      {
         return ReadSteamJsonFile(_path);
      }
   }
}
