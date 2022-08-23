namespace BLL.Models.BaseModels.Devices
{
   public class GruDevices
   {
      public GruDevices()
      {
         Gru1 = new Device();
         Gru2 = new Device();
      }
      public Device Gru1 { get; set; }
      public Device Gru2 { get; set; }
   }
}
