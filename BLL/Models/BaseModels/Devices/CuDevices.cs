namespace BLL.Models.BaseModels.Devices
{
   public class CuDevices
   {
      public CuDevices()
      {
         Cu1 = new Device();
         Cu2 = new Device();
      }
      public Device Cu1 { get; set; }
      public Device Cu2 { get; set; }
   }
}
