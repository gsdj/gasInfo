using Business.DTO.Models.General;

namespace Business.DTO.Models.InfoSheet
{
   public class ConsumptionDg
   {
      //Расход доменного газа на обогрев (Оценочный, приведение "М-К")
      public CbKc Month { get; set; } // ст.м³ с начала месяца
      public CbKc Day { get; set; } // ст.м³ (1000кКал/м³)
      public CbKc Hour { get; set; } // ст.м³/час
      public CbKc UdFv { get; set; } // Удельный, ст.м³/тн. шихты в ф.в.
   }
}
