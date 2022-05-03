using Business.DTO.Consumption;
using Business.DTO.General;
using System;

namespace Business.DTO
{
   public class EbChmkDTO
   {
      public DateTime Date { get; set; }
      public CbKc ConsumptionKc1 { get; set; }
      public decimal ConsDgKc1Sum { get; set; }
      public CbKc UdConsumptionKc1 { get; set; }
      public int UdConsKc1Sum { get; set; }
      public ConsumptionGru<decimal> ConsumptionGru { get; set; }
      public decimal ConsPgUpc { get; set; }
      public ConsumptionGru<decimal> UdConsumptionGru { get; set; }
   }
}
