using Business.DTO.Models.General;

namespace Business.DTO.Input
{
   public class PressureDTO : Entity
   {
      public decimal Value { get; set; }
      public decimal ValuePa { get; set; } 
   }
}
