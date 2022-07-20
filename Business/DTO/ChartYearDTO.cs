using Business.DTO.Models.General;

namespace Business.DTO
{
   public class ChartYearDTO : Entity
   {
      public decimal TradeGasMK { get; set; }
      public decimal TradeGasEB { get; set; }
      public decimal TradeGasAsdue { get; set; }
      public decimal TradeGasTn { get; set; }
      public decimal TradeGasV { get; set; }
      public decimal TradeGasDev { get; set; }
   }
}
