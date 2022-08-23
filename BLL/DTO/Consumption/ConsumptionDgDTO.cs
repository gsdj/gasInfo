using BLL.Models.BaseModels.General;
using BLL.Models.BaseModels.QcRc;

namespace BLL.DTO.Consumption
{
   public class ConsumptionDgDTO : Entity
   {
      public ConsumptionDgDTO()
      {
         QcRc = new QcRcKc1();
         ConsumptionDg = new CbKc();
      }
      public QcRcKc1 QcRc { get; set; }
      public CbKc ConsumptionDg { get; set; }
      public decimal ConsumptionDgMk { get; set; }
   }
}
