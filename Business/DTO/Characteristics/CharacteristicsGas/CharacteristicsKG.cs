using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO.Characteristics.CharacteristicsGas
{
   public class CharacteristicsKG : CharacteristicsBase
   {
      public decimal O2 { get; set; } = 0;
      public decimal CnHm { get; set; } = 0;
      public decimal CH4 { get; set; } = 0;
      public decimal SumComponents { get; set; }
      public decimal Qn { get; set; }
      public decimal Density { get; set; }
   }
}
