using BLL.Models.BaseModels.General;

namespace BLL.DTO
{
   public class EbChmkDTO : Entity
   {
      public EbChmkDTO()
      {
         ConsumptionKc1 = new CbKc();
         UdConsumptionKc1 = new CbKc();
         ConsumptionGru = new Gru();
         UdConsumptionGru = new Gru();
      }
      public CbKc ConsumptionKc1 { get; set; }
      public decimal ConsDgKc1Sum { get; set; }
      public CbKc UdConsumptionKc1 { get; set; }
      public int UdConsKc1Sum { get; set; }
      public Gru ConsumptionGru { get; set; }
      public decimal ConsPgUpc { get; set; }
      public Gru UdConsumptionGru { get; set; }
   }
}
