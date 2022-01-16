using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities.Characteristics
{
   public class KG : Characteristics
   {
      public decimal O2 { get; set; } = 0;
      public decimal CnHm { get; set; } = 0;
      public decimal CH4 { get; set; } = 0;
   }
}
