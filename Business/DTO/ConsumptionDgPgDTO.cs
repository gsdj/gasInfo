using Business.DTO.Consumption;
using Business.DTO.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
   public class ConsumptionDgPgDTO
   {
      public DateTime Date { get; set; }
      public CbKc ConsumptionDgCb { get; set; }
      public decimal ConsumptionDgKc1 { get; set; }
      public CbKc ConsumptionPgCb { get; set; }
      public decimal ConsumptionPgKc1 { get; set; }
      public ConsumptionGru<decimal> ConsumptionPgGru { get; set; }
      public ConsumptionGru<decimal> UdConsumptionPgGru { get; set; }
      public CbKc UdConsumptionKgFvCb { get; set; }
      public decimal UdConsumptionKgFvKc1 { get; set; }
   }
}
