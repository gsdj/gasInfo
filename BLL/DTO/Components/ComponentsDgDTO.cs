using BLL.Models.BaseModels.Components;
using BLL.Models.BaseModels.General;

namespace BLL.DTO.Components
{
   public class ComponentsDgDTO : Entity
   {
      public GasComponents Kc1 { get; set; }
      public GasComponents Kc2 { get; set; }
   }
}
