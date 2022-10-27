namespace DA.Entities.Devices
{
   public abstract class BaseDevice
   {
      public virtual int Pressure { get; set; }
      public virtual decimal Temperature { get; set; }
   }
}
