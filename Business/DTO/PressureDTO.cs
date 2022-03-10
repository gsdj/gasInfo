using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
   public class PressureDTO
   {
      public DateTime Date { get; set; }
      public decimal Value { get; set; }
      public decimal ValuePa { get; set; } 
   }
}
