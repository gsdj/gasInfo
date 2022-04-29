namespace Business.DTO.QcRc
{
   public class QcRcKc1
   {
      public QcRcKc1()
      {
         Cb1 = new QcRcOnMultiplier2();
         Cb2 = new QcRcOnMultiplier2();
         Cb3 = new QcRcOnMultiplier2();
         Cb4 = new QcRcOnMultiplier2();
      }
      public QcRcOnMultiplier2 Cb1 { get; set; }
      public QcRcOnMultiplier2 Cb2 { get; set; }
      public QcRcOnMultiplier2 Cb3 { get; set; }
      public QcRcOnMultiplier2 Cb4 { get; set; }
      //public decimal Cb1 { get; set; }
      //public decimal Cb2 { get; set; }
      //public decimal Cb3 { get; set; }
      //public decimal Cb4 { get; set; }
   }
}
