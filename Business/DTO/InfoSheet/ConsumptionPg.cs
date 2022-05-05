using Business.DTO.General;

namespace Business.DTO.InfoSheet
{
   public class ConsumptionPg
   {
      public Gru Month { get; set; } // ст.м³ с начала месяца
      public Gru Day { get; set; } // ст.м³ (1000кКал/м³)
      public Gru Hour { get; set; } // ст.м³/час
      public Gru UdFv { get; set; } // Удельный, ст.м³/тн. шихты в ф.в.
   }
}
