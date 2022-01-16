using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities.Devices
{
   public class Cb7 : Device
   {
      public int ConsumptionMs { get; set; } = 0;
      public int ConsumptionKs { get; set; } = 0;
      public decimal TempBeforeHeating { get; set; } = 0;
   }
}
