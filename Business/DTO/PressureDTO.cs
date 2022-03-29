using System;

namespace Business.DTO
{
   public class PressureDTO
   {
      public DateTime Date { get; set; }
      public decimal Value { get; set; }
      public decimal ValuePa { get; set; } 
   }
}
