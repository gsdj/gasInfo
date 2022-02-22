using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO.Characteristics.CharacteristicsGas
{
   public class CharacteristicsDG 
   {
      public GasComponents Components { get; set; }
      public decimal SumComponents { get; set; }
      public CharacteristicsGas Characteristics { get; set; }
   }
}
