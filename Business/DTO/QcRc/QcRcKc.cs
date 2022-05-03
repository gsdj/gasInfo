namespace Business.DTO.QcRc
{
   public class QcRcKc
   {
      public QcRcKc()
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
   }

   public class QcRcKc1 : QcRcKc { }
   public class QcRcKc2 : QcRcKc { }
}
