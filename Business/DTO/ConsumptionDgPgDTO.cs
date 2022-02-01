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
      public decimal ConsDgCb1 { get; set; }
      public decimal ConsDgCb2 { get; set; }
      public decimal ConsDgCb3 { get; set; }
      public decimal ConsDgCb4 { get; set; }
      public decimal Kc1Sum { get; set; }
      public decimal ConsPgKc1 { get; set; }
      public decimal ConsPgCb1 { get; set; }
      public decimal ConsPgCb2 { get; set; }
      public decimal ConsPgCb3 { get; set; }
      public decimal ConsPgCb4 { get; set; }
      public decimal ConsPgGru1 { get; set; }
      public decimal ConsPgGru2 { get; set; }
      public decimal UdConsPgGru1 { get; set; }
      public decimal UdConsPgGru2 { get; set; }
      public decimal UdConsKgFvCb1 { get; set; }
      public decimal UdConsKgFvCb2 { get; set; }
      public decimal UdConsKgFvCb3 { get; set; }
      public decimal UdConsKgFvCb4 { get; set; }
      public decimal UdConsKgFvKc1 { get; set; }
   }
}
