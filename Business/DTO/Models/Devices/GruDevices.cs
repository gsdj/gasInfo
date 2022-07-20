using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO.Models.Devices
{
   public class GruDevices
   {
      public GruDevices()
      {
         Gru1 = new Device();
         Gru2 = new Device();
      }
      public Device Gru1 { get; set; }
      public Device Gru2 { get; set; }
   }
}
