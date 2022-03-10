using Business.DTO.Characteristics.CharacteristicsGas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
   public class ComponentsKgDTO
   {
      public DateTime Date { get; set; }
      public KGasComponents Kc1 { get; set; }
      public KGasComponents Kc2 { get; set; }
   }
}
