using BLL.Models.BaseModels.General;

namespace BLL.DTO.Charts
{
   public class ChartMonthDTO : Entity
   {
      public decimal TheorOutKg { get; set; }
      public decimal OperOutKg { get; set; }
      public decimal TradeOutKg { get; set; }
      public decimal TradeChmkOutKg { get; set; }
   }
}
