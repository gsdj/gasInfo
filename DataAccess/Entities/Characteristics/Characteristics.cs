using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities.Characteristics
{
   public abstract class Characteristics
   {
      public decimal CO2 { get; set; } = 0;
      public decimal CO { get; set; } = 0;
      public decimal N2 { get; set; } = 0;
      public decimal H2 { get; set; } = 0;
   }
}
