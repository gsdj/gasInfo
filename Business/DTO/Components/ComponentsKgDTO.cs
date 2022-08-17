using Business.DTO.Models.Components;
using Business.DTO.Models.General;

namespace Business.DTO.Components
{
   public class ComponentsKgDTO : Entity
   {
      public KGasComponents Kc1 { get; set; }
      public KGasComponents Kc2 { get; set; }
   }
}
