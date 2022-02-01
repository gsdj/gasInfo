using Business.DTO.Characteristics.CharacteristicsGas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
   public class CharacteristicsDgDTO
   {
      public DateTime Date { get; set; }
      public CharacteristicsDG Kc1 { get; set; }
      public CharacteristicsDG Kc2 { get; set; }
      public decimal H2Avg { get; set; }
      public decimal COAvg { get; set; }
      public decimal CO2Avg { get; set; }
      public decimal N2Avg { get; set; }
      public decimal Qn { get; set; }
      public decimal Denstity { get; set; }
   }
}
