namespace Business.DTO.Models.Devices
{
   public class Kc1Devices
   {
      public Kc1Devices()
            {
               Cb1 = new Device();
               Cb2 = new Device();
               Cb3 = new Device();
               Cb4 = new Device();
            }
      public Device Cb1 { get; set; }
      public Device Cb2 { get; set; }
      public Device Cb3 { get; set; }
      public Device Cb4 { get; set; }
   }
}
