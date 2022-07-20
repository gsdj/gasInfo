using Business.DTO.Models.General;
using Business.DTO.Models.QcRc;

namespace Business.DTO
{
   public class ConsumptionKgDTO : Entity
   {
      public ConsumptionKgDTO()
      {
         QcRcCb = new QcRcKc2();
         ConsumptionCb = new CbKc();
         QcRcCpsPpk = new CpsPpkQcRc();
         ConsumptionCpsPpk = new CpsPpk();
      }
      public QcRcKc2 QcRcCb { get; set; }
      public CbKc ConsumptionCb { get; set; }
      public CpsPpkQcRc QcRcCpsPpk { get; set; }
      public CpsPpk ConsumptionCpsPpk { get; set; }
      public decimal QcRcGsuf { get; set; }
      public decimal ConsumptionGsuf { get; set; }
      public decimal ConsumptionKc2Sum { get; set; }
      public decimal PkoQcRcSum { get; set; }
      public decimal ConsumptionCpsPpkSum { get; set; }
      public decimal ConsumptionMkSum { get; set; }
      public decimal ConsumptionMkGsufSum { get; set; }
   }
}
