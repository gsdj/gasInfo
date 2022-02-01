using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
   public class ChartYearDTO
   {
      public DateTime Date { get; set; }
      public decimal TradeGasMK { get; set; }
      public decimal TradeGasEB { get; set; }
      public decimal TradeGasAsdue { get; set; }
      public decimal TradeGasTn { get; set; }
      public decimal TradeGasV { get; set; }
      public decimal TradeGasDev { get; set; }
   }
}
