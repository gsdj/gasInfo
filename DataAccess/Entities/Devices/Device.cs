using DataAccess.Entities.Characteristics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities.Devices
{
   public abstract class Device
   {
      public int Pressure { get; set; } = 0;
      public decimal Temperature { get; set; } = 0;
      public SteamCharacteristics SteamCharacteristics { get; set; }
   }
}
