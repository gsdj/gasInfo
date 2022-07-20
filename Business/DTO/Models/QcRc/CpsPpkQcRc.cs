using Business.DTO.Models.General;

namespace Business.DTO.Models.QcRc
{
   public class CpsPpkQcRc
   {
      public CpsPpkQcRc()
      {
         Pko = new PkoQcRc();
      }
      public PkoQcRc Pko { get; set; }
      public decimal Spo { get; set; }
   }
   public class PkoQcRc : Pko
   {
      public PkoQcRc()
      {
         Pkp = new QcRcDefault();
      }
      public QcRcDefault Pkp { get; set; }
      public decimal Total { get { return Pkp.Value + Uvtp; } }
   }
}
