namespace Business.DTO.General
{
   public class CbAll
   {
      public CbAll()
      {
         Kc1 = new CbKc();
         Kc2 = new CbKc();
      }
      public CbKc Kc1 { get; set; }
      public CbKc Kc2 { get; set; }
   }
   public class CbKc
   {
      public decimal Cb1 { get; set; }
      public decimal Cb2 { get; set; }
      public decimal Cb3 { get; set; }
      public decimal Cb4 { get; set; }
   }
}
