namespace Business.DTO.QcRc
{
   public class QcRcCpsPpk
   {
      public QcRcCpsPpk()
      {
         Pko = new QcRcDefault2();
      }
      public QcRcDefault2 Pko { get; set; }
      public decimal Uvtp { get; set; }
      public decimal Spo { get; set; }
      public decimal Gsuf { get; set; }
   }
}
