using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Entities.Devices
{
   public class DeviceTBHMsKs : DeviceWithTempBeforeHeating
   {
      public DeviceTBHMsKs()
      {
         Consumption = new ConsumptionMsKs();
      }
      public ConsumptionMsKs Consumption { get; set; }
   }
}
