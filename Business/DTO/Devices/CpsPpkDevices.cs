namespace Business.DTO.Devices
{
   public class CpsPpkDevices
   {
      public CpsPpkDevices()
      {
         Pko = new Pko();
         Spo = new Device();
      }
      public Pko Pko { get; set; }
      public Device Spo { get; set; }
   }
   public class Pko
   {
      public Pko()
      {
         Pkp = new Device();
         Uvtp = new Device();
      }
      public Device Pkp { get; set; }
      public Device Uvtp { get; set; }
   }
}
