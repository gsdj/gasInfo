using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
   public class ReportKgDTO
   {
      public DateTime Date { get; set; }
      public decimal OutKgPko { get; set; }
      public decimal OutKgCb16 { get; set; }// => Math.Round((Kbs16 == 0 || KbsMk == 0) ? 0 : (OutKgKb18 * (Kbs16 / KbsMk)), 10);
      public decimal OutKgCb78 { get; set; }// =>=> Math.Round((Kbs78 == 0 || KbsMk == 0) ? 0 : (OutKgKb18 * (Kbs78 / KbsMk)), 10);
      public decimal OutKgCb18 { get; set; }//=> Math.Round((OutKgMk - OutKgPko), 10);
      public decimal OutKgMk { get; set; }
      public decimal KipSpr { get; set; }

      public decimal OutKgDryPkp { get; set; }
      public decimal OutKgDryCb16 { get; set; }//=> Math.Round((OutKgKb16 == 0 || ConsSuhKb16 == 0) ? 0 : (OutKgKb16 / ConsSuhKb16), 10);
      public decimal OutKgDryCb78 { get; set; }//=> Math.Round((OutKgKb78 == 0 || ConsSuhKb78 == 0) ? 0 : (OutKgKb78 / ConsSuhKb78), 10);
      public decimal OutKgDryMk { get; set; }//=> Math.Round((OutKgKb18 == 0 || TnConsSuh == 0) ? 0 : (OutKgKb18 / TnConsSuh), 10);

      public decimal ConsKgCb5 { get; set; }
      public decimal ConsKgCb6 { get; set; }
      public decimal ConsKgCb7 { get; set; }
      public decimal ConsKgCb8 { get; set; }
      public decimal ConsKgKc2 => Math.Round((ConsKgCb5 + ConsKgCb6 + ConsKgCb7 + ConsKgCb8), 10);
      public decimal ConsKgSpo { get; set; }
      public decimal ConsKgPkp { get; set; }
      public decimal ConsKgUvtp { get; set; }
      public decimal ConsKgCpsPpk => Math.Round((ConsKgSpo + ConsKgPkp + ConsKgUvtp), 10);
      public decimal ConsKgMk => Math.Round((ConsKgKc2 + ConsKgCpsPpk), 10);

      public decimal ConsFvCb5 { get; set; }
      public decimal ConsFvCb6 { get; set; }
      public decimal ConsFvCb7 { get; set; }
      public decimal ConsFvCb8 { get; set; }
      public decimal ConsFvKc2 { get; set; }
      public decimal ConsFvSpo { get; set; }
      public decimal ConsFvPko { get; set; }
      public decimal ConsFvCpsPpk { get; set; }

      public decimal ConsGsuf { get; set; }
      public decimal TradeGasChmk { get; set; }
   }
}
