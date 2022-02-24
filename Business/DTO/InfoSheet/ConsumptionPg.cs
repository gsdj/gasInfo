using Business.DTO.Consumption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO.InfoSheet
{
   public class ConsumptionPg
   {
      public ConsumptionGru<decimal> Month { get; set; } // ст.м³ с начала месяца
      public ConsumptionGru<decimal> Day { get; set; } // ст.м³ (1000кКал/м³)
      public ConsumptionGru<decimal> Hour { get; set; } // ст.м³/час
      public ConsumptionGru<decimal> UdFv { get; set; } // Удельный, ст.м³/тн. шихты в ф.в.
   }
}
