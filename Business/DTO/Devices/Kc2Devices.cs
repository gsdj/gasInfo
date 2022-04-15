
namespace Business.DTO.Devices
{
   public class Kc2Devices
   {
      public Kc2Devices()
            {
               Cb5 = new Kc2Device();
               Cb6 = new Kc2Device();
               Cb7 = new Kc2Device();
               Cb8 = new Kc2Device();
            }
      public Kc2Device Cb5 { get; set; }
      public Kc2Device Cb6 { get; set; }
      public Kc2Device Cb7 { get; set; }
      public Kc2Device Cb8 { get; set; }
   }

   public class Kc2Device : Device
   {
      public decimal TempBeforeHeating { get; set; } = 0;
   }
}
