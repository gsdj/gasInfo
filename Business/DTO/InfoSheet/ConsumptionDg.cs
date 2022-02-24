using Business.DTO.Consumption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO.InfoSheet
{
   public class ConsumptionDg
   {
      //Расход доменного газа на обогрев (Оценочный, приведение "М-К")
      public ConsumptionKc1<decimal> Month { get; set; } // ст.м³ с начала месяца
      public ConsumptionKc1<decimal> Day { get; set; } // ст.м³ (1000кКал/м³)
      public ConsumptionKc1<decimal> Hour { get; set; } // ст.м³/час
      public ConsumptionKc1<decimal> UdFv { get; set; } // Удельный, ст.м³/тн. шихты в ф.в.
   }
}
