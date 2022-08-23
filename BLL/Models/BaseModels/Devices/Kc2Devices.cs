namespace BLL.Models.BaseModels.Devices
{
   public class Kc2Devices
   {
      public Kc2Devices()
      {
         Cb1 = new Kc2Device();
         Cb2 = new Kc2Device();
         Cb3 = new Kc2Device();
         Cb4 = new Kc2Device();
      }
      public Kc2Device Cb1 { get; set; }
      public Kc2Device Cb2 { get; set; }
      public Kc2Device Cb3 { get; set; }
      public Kc2Device Cb4 { get; set; }
   }

   public class Kc2Device : Device
   {
      public decimal TempBeforeHeating { get; set; } = 0;
   }
}
