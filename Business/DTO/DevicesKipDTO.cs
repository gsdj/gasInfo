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
         //Cu1 = new Cu1();
         //Cu2 = new Cu2();
         //Cb5 = new Cb5();
         //Cb6 = new Cb6();
         //Cb7 = new Cb7();
         //Cb8 = new Cb8();
         //Pkc = new Pkc();
         //Uvtp = new Uvtp();
         //Spo = new Spo();
         Gsuf45 = new Device();
         //Cb1 = new Cb1();
         //Cb2 = new Cb2();
         //Cb3 = new Cb3();
         //Cb4 = new Cb4();
         Gru1 = new Device();
         Gru2 = new Device();
         Grp4 = new Device();
      }
      public DateTime Date { get; set; }
      public CuDevices Cu { get; set; }
      public Kc2Devices Kc2 { get; set; }
      public CpsPpkDevices CpsPpk { get; set; }
      public Kc1Devices Kc1 { get; set; }
      //public Cu1 Cu1 { get; set; }
      //public Cu2 Cu2 { get; set; }
      //public Cb5 Cb5 { get; set; }
      //public Cb6 Cb6 { get; set; }
      //public Cb7 Cb7 { get; set; }
      //public Cb8 Cb8 { get; set; }
      //public Pkc Pkc { get; set; }
      //public Uvtp Uvtp { get; set; }
      //public Spo Spo { get; set; }
      public Device Gsuf45 { get; set; }
      //public Cb1 Cb1 { get; set; }
      //public Cb2 Cb2 { get; set; }
      //public Cb3 Cb3 { get; set; }
      //public Cb4 Cb4 { get; set; }
      public Device Gru1 { get; set; }
      public Device Gru2 { get; set; }
      public Device Grp4 { get; set; }
   }
}
