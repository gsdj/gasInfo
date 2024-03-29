﻿using BLL.Models.BaseModels.General;

namespace BLL.Models.BaseModels.InfoSheet
{
   public class ConsumptionPg
   {
      public ConsumptionPg()
      {
         Month = new Gru();
         Day = new Gru();
         Hour = new Gru();
         UdFv = new Gru();
      }
      public Gru Month { get; set; } // ст.м³ с начала месяца
      public Gru Day { get; set; } // ст.м³ (1000кКал/м³)
      public Gru Hour { get; set; } // ст.м³/час
      public Gru UdFv { get; set; } // Удельный, ст.м³/тн. шихты в ф.в.
   }
}
