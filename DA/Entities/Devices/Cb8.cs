﻿namespace DA.Entities.Devices
{
   public class Cb8 : Device
   {
      public int ConsumptionMs { get; set; } = 0;
      public int ConsumptionKs { get; set; } = 0;
      public decimal TempBeforeHeating { get; set; } = 0;
   }
}