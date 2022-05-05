using Business.DTO.Devices;
using System;

namespace Business.DTO
{
   public class DevicesKipDTO
   {
      public DevicesKipDTO()
      {
         Cu = new CuDevices();
         Kc2 = new Kc2Devices();
         CpsPpk = new CpsPpkDevices();
         Kc1 = new Kc1Devices();
         Gsuf45 = new Device();
         Gru = new GruDevices();
         Grp4 = new Device();
      }
      public DateTime Date { get; set; }
      public CuDevices Cu { get; set; }
      public Kc2Devices Kc2 { get; set; }
      public CpsPpkDevices CpsPpk { get; set; }
      public Kc1Devices Kc1 { get; set; }
      public Device Gsuf45 { get; set; }
      public GruDevices Gru { get; set; }
      public Device Grp4 { get; set; }
   }
}
