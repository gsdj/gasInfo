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
      public CharacteristicsDgDTO()
      {
         Kc1 = new CharacteristicsDG();
         Kc2 = new CharacteristicsDG();
         ComponentsAVG = new GasComponents();
         CharacteristicsAVG = new CharacteristicsGas();
      }
      public DateTime Date { get; set; }
      public CharacteristicsDG Kc1 { get; set; }
      public CharacteristicsDG Kc2 { get; set; }
      public GasComponents ComponentsAVG { get; set; }
      public CharacteristicsGas CharacteristicsAVG { get; set; }
   }
}
