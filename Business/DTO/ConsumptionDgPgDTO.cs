using Business.DTO.Models.General;

namespace Business.DTO
{
   public class ConsumptionDgPgDTO : Entity
   {
      public CbKc ConsumptionDgCb { get; set; }
      public decimal ConsumptionDgKc1 { get; set; }
      public CbKc ConsumptionPgCb { get; set; }
      public decimal ConsumptionPgKc1 { get; set; }
      public Gru ConsumptionPgGru { get; set; }
      public Gru UdConsumptionPgGru { get; set; }
      public CbKc UdConsumptionKgFvCb { get; set; }
      public decimal UdConsumptionKgFvKc1 { get; set; }
   }
}
