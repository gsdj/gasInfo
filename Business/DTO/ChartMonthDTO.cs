using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
   public class ChartMonthDTO
   {
      public DateTime Date { get; set; }
      public decimal TheorOutKg { get; set; }
      public decimal OperOutKg { get; set; }
      public decimal TradeOutKg { get; set; }
      public decimal TradeChmkOutKg { get; set; }
   }
}
