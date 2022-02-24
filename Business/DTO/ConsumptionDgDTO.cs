using Business.DTO.Consumption;
using Business.DTO.QcRc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
   public class ConsumptionDgDTO
   {
      public DateTime Date { get; set; }
      public QcRcKc1 QcRc { get; set; }
      public ConsumptionKc1<decimal> ConsumptionDg { get; set; }
      public decimal ConsumptionDgMk { get; set; }
   }
}
