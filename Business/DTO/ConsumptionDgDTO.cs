using Business.DTO.Models.General;
using Business.DTO.Models.QcRc;

namespace Business.DTO
{
   public class ConsumptionDgDTO : Entity
   {
      public QcRcKc1 QcRc { get; set; }
      public CbKc ConsumptionDg { get; set; }
      public decimal ConsumptionDgMk { get; set; }
   }
}
