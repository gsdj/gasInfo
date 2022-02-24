using Business.DTO.Consumption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO.InfoSheet
{
   public class ConsumptionKg
   {
      public ConsumptionKc2 MonthCb { get; set; } // ст.м³ с начала месяца
      public ConsumptionKc2 DayCb { get; set; } // ст.м³ (4000кКал/м³)
      public ConsumptionKc2 HourCb { get; set; } // ст.м³/час
      public ConsumptionKc2 UdSvCb { get; set; } // Удельный, ст.м³/тн. шихты в c.в.
      public ConsumptionCpsPpk MonthCpsPpk { get; set; } // ст.м³ с начала месяца
      public ConsumptionCpsPpk DayCpsPpk { get; set; } // ст.м³ (4000кКал/м³)
      public ConsumptionCpsPpk HourCpsPpk { get; set; } // ст.м³/час
      public ConsumptionCpsPpk UdSvCpsPpk { get; set; } // Удельный, ст.м³/тн. шихты в c.в.
      public decimal ConsKgMonthCpsPpk { get; set; }
      public decimal ConsKgDayCpsPpk { get; set; }
      public decimal ConsKgHourCpsPpk { get; set; }
      public decimal ConsKgUdSvCpsPpk { get; set; }
      public decimal ConsKgMkMonth { get; set; }
      public decimal ConsKgMkDay { get; set; }
      public decimal ConsKgMkHour { get; set; }
      //Расход КГ на обогрев
      //public decimal ConsKgObUdSvCb5 { get; set; }
      //public decimal ConsKgObUdSvCb6 { get; set; }
      //public decimal ConsKgObUdSvCb7 { get; set; }
      //public decimal ConsKgObUdSvCb8 { get; set; }
      //public decimal ConsKgObUdSvSpo { get; set; }
      //public decimal ConsKgObUdSvPko { get; set; }
      //public decimal ConsKgObUdSvCpsppk { get; set; }

      //public decimal ConsKgObStCb5 { get; set; }
      //public decimal ConsKgObStCb6 { get; set; }
      //public decimal ConsKgObStCb7 { get; set; }
      //public decimal ConsKgObStCb8 { get; set; }
      //public decimal ConsKgObStSpo { get; set; }
      //public decimal ConsKgObStPko { get; set; }
      //public decimal ConsKgObStCpsppk { get; set; }
      //public decimal ConsKgObStMk { get; set; }

      //public decimal ConsKgObSthCb5 { get; set; }//=> (ConsKgObStCb5 == 0) ? 0 : Math.Round((ConsKgObStCb5 / 24), 2);
      //public decimal ConsKgObSthCb6 { get; set; }//=> (ConsKgObStCb6 == 0) ? 0 : Math.Round((ConsKgObStCb6 / 24), 2);
      //public decimal ConsKgObSthCb7 { get; set; }//=> (ConsKgObStCb7 == 0) ? 0 : Math.Round((ConsKgObStCb7 / 24), 2);
      //public decimal ConsKgObSthCb8 { get; set; }//=> (ConsKgObStCb8 == 0) ? 0 : Math.Round((ConsKgObStCb8 / 24), 2);
      //public decimal ConsKgObSthSpo { get; set; }//=> (ConsKgObStSpo == 0) ? 0 : Math.Round((ConsKgObStSpo / 24), 2);
      //public decimal ConsKgObSthPko { get; set; }//=> (ConsKgObStPko == 0) ? 0 : Math.Round((ConsKgObStPko / 24), 2);
      //public decimal ConsKgObSthCpsppk { get; set; }//=> (ConsKgObStCpsppk == 0) ? 0 : Math.Round((ConsKgObStCpsppk / 24), 2);
      //public decimal ConsKgObSthMk { get; set; }//=> (ConsKgObStMk == 0) ? 0 : Math.Round((ConsKgObStMk / 24), 2);

      //public decimal SumConsKgCb5 { get; set; }
      //public decimal SumConsKgCb6 { get; set; }
      //public decimal SumConsKgCb7 { get; set; }
      //public decimal SumConsKgCb8 { get; set; }
      //public decimal SumConsKgSpo { get; set; }
      //public decimal SumConsKgPko { get; set; }
      //public decimal SumConsKgCpsppk { get; set; }
      //public decimal SumConsKgMk { get; set; }
   }
}
