using DataAccess.Entities.Characteristics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities.Devices
{
   public class Uvtp : Device
   {
      public int Consumption { get; set; } = 0;
   }
}
