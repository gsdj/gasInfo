using Business.DTO.Consumption;

namespace Business.DTO.General
{
   public class CpsPpk
   {
      public CpsPpk()
      {
         Pko = new PkoConsumption();
      }
      public PkoConsumption Pko { get; set; }
      public decimal Spo { get; set; }
   }
   public class CpsPpkQcRc
   {
      public CpsPpkQcRc()
      {
         Pko = new PkoQcRc();
      }
      public PkoQcRc Pko { get; set; }
      public decimal Spo { get; set; }
   }
   public class Pko
   {
      public decimal Uvtp { get; set; }
   }
   public class PkoQcRc : Pko
   {
      public PkoQcRc()
      {
         Pkp = new QcRcDefault2();
      }
      public QcRcDefault2 Pkp { get; set; }
      public decimal Total { get { return Pkp.Value + Uvtp; } }
   }
   public class PkoConsumption : Pko
   {
      public decimal Pkp { get; set; }
   }
}
