using BLL.Models.BaseModels.Components;
using BLL.Models.BaseModels.General;

namespace BLL.DTO.Components
{
   public class ComponentsKgDTO : Entity
   {
      public KGasComponents Kc1 { get; set; }
      public KGasComponents Kc2 { get; set; }
   }
}
