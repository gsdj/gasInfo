using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO.Characteristics.CharacteristicsGas
{
   public abstract class CharacteristicsBase
   {
      public decimal CO2 { get; set; } = 0;
      public decimal CO { get; set; } = 0;
      public decimal N2 { get; set; } = 0;
      public decimal H2 { get; set; } = 0;
   }
}
