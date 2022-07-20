using Business.DTO.Models.Components;
using Business.DTO.Models.General;

namespace Business.DTO
{
   public class ComponentsDgDTO : Entity
   {
      public GasComponents Kc1 { get; set; }
      public GasComponents Kc2 { get; set; }
   }
}
