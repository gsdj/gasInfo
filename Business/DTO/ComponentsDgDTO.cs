using Business.DTO.Characteristics.CharacteristicsGas;
using System;

namespace Business.DTO
{
   public class ComponentsDgDTO
   {
      public DateTime Date { get; set; }
      public GasComponents Kc1 { get; set; }
      public GasComponents Kc2 { get; set; }
   }
}
