using Business.DTO.Characteristics.CharacteristicsGas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
   public class ComponentsDgDTO
   {
      public DateTime Date { get; set; }
      public GasComponents Kc1 { get; set; }
      public GasComponents Kc2 { get; set; }
   }
}
