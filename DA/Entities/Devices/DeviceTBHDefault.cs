using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Entities.Devices
{
   public class DeviceTBHDefault : DeviceWithTempBeforeHeating
   {
      public int Consumption { get; set; } = 0;
   }
}
