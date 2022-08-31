using DA.Entities.Devices;
using DA.Interfaces;
using System;

namespace DA.Entities
{
   public class DevicesKip : IGasEntity
   {
      public Guid Id { get; set; }
      public DateTime Date { get; set; }
      public DeviceDefault Cu1 { get; set; }
      public DeviceDefault Cu2 { get; set; }
      public DeviceTBHDefault Cb5 { get; set; }
      public DeviceTBHDefault Cb6 { get; set; }
      public DeviceTBHMsKs Cb7 { get; set; }
      public DeviceTBHMsKs Cb8 { get; set; }
      public DeviceMsKs Pkc { get; set; }
      public DeviceDefault Uvtp { get; set; }
      public DeviceDefault Spo { get; set; }
      public DeviceDefault Gsuf45 { get; set; }
      public DeviceDefault Cb1 { get; set; }
      public DeviceDefault Cb2 { get; set; }
      public DeviceDefault Cb3 { get; set; }
      public DeviceDefault Cb4 { get; set; }
      public DeviceDefault Gru1 { get; set; }
      public DeviceDefault Gru2 { get; set; }
      public DeviceDefault Grp4 { get; set; }
   }
}
