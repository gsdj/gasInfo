using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
   public class AsdueDTO
   {
      public DateTime Date { get; set; }
      public decimal TecNorth { get; set; } = 0;
      public decimal TecSouth { get; set; } = 0;
      public decimal Gps2Gss1 { get; set; } = 0;
      public decimal Gps2Gss2 { get; set; } = 0;
      public decimal NaturalGasQn { get; set; } = 0;
      public decimal OutPkg { get; set; } = 0;
      public decimal StmDay { get; set; }//=> (TecNorth + TecSouth + Gps2Gss1 + Gps2Gss2);
   }
}
