namespace DA.Entities.Devices
{
   public abstract class BaseDevice
   {
      public int Pressure { get; set; } = 0;
      public decimal Temperature { get; set; } = 0;
   }
}
