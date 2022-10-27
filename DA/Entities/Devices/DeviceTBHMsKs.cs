using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Entities.Devices
{
   public class DeviceTBHMsKs : DeviceWithTempBeforeHeating
   {
      public virtual ConsumptionMsKs Consumption { get; set; }
   }
}
