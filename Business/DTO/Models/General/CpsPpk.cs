using Business.DTO.Models.Consumption;

namespace Business.DTO.Models.General
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
