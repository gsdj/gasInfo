using Business.DTO.Consumption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
   public class EbChmkDTO
   {
      public DateTime Date { get; set; }
      public ConsumptionKc1<decimal> ConsumptionKc1 { get; set; }
      public decimal ConsDgKc1Sum { get; set; }
      public ConsumptionKc1<int> UdConsumptionKc1 { get; set; }
      public int UdConsKc1Sum { get; set; }
      public ConsumptionGru<decimal> ConsumptionGru { get; set; }
      public decimal ConsPgUpc { get; set; }
      public ConsumptionGru<decimal> UdConsumptionGru { get; set; }
   }
}
