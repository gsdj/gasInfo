using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO.Devices
{
   public class Cb5 : Device
   {
      public int Consumption { get; set; } = 0;
      public decimal TempBeforeHeating { get; set; } = 0;
   }
}
