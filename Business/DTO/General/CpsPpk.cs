
namespace Business.DTO.General
{
   public class CpsPpk
   {
      public CpsPpk()
      {
         Pko = new Pko();
      }
      public Pko Pko { get; set; }
      public decimal Spo { get; set; }
   }
   public class Pko
   {
      public decimal Pkp { get; set; }
      public decimal Uvtp { get; set; }
   }
}
