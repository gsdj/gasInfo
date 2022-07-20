namespace Business.DTO.Models.QcRc
{
   public class QcRcKc
   {
      public QcRcKc()
      {
         Cb1 = new QcRcOnMultiplier();
         Cb2 = new QcRcOnMultiplier();
         Cb3 = new QcRcOnMultiplier();
         Cb4 = new QcRcOnMultiplier();
      }
      public QcRcOnMultiplier Cb1 { get; set; }
      public QcRcOnMultiplier Cb2 { get; set; }
      public QcRcOnMultiplier Cb3 { get; set; }
      public QcRcOnMultiplier Cb4 { get; set; }
   }

   public class QcRcKc1 : QcRcKc { }
   public class QcRcKc2 : QcRcKc { }
}
