using BLL.Models.BaseModels.General;

namespace BLL.DTO.Input
{
   public class PressureDTO : Entity
   {
      public decimal Value { get; set; }
      public decimal ValuePa { get; set; } 
   }
}
