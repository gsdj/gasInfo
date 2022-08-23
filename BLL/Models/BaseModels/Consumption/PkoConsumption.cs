using BLL.Models.BaseModels.General;

namespace BLL.Models.BaseModels.Consumption
{
   public class PkoConsumption : Pko
   {
      public decimal Pkp { get; set; }
      private decimal _total;
      public decimal Total { get { return Pkp + Uvtp; } set { _total = value; } }
   }
}
