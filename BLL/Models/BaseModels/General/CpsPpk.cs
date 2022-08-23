using BLL.Models.BaseModels.Consumption;

namespace BLL.Models.BaseModels.General
{
   public class CpsPpk
   {
      public CpsPpk()
      {
         Pko = new PkoConsumption();
      }
      public PkoConsumption Pko { get; set; }
      public decimal Spo { get; set; }
      public decimal Sum => Pko.Total + Spo;
   }

   public class Pko
   {
      public decimal Uvtp { get; set; }
   }
}
