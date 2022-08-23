using BLL.Models.BaseModels.Components;
using BLL.Models.BaseModels.General;

namespace BLL.DTO.Components
{
   public class QualityComponentsDTO : Entity
   {
      public QualityComponents Kc1 { get; set; }
      public QualityComponents Kc2 { get; set; }
   }
}
