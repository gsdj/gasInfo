using Business.DTO.Models.General;

namespace Business.DTO.Models.Consumption
{
   public class PkoConsumption : Pko
   {
      public decimal Pkp { get; set; }
      private decimal _total;
      public decimal Total { get { return Pkp + Uvtp; } set { _total = value; } }
   }
}
