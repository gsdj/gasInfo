using Business.DTO.Models.General;

namespace Business.DTO
{
   public class ChartMonthDTO : Entity
   {
      public decimal TheorOutKg { get; set; }
      public decimal OperOutKg { get; set; }
      public decimal TradeOutKg { get; set; }
      public decimal TradeChmkOutKg { get; set; }
   }
}
