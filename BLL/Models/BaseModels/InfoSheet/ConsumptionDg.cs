using BLL.Models.BaseModels.General;

namespace BLL.Models.BaseModels.InfoSheet
{
   public class ConsumptionDg
   {
      public ConsumptionDg()
      {
         Month = new CbKc();
         Day = new CbKc();
         Hour = new CbKc();
         UdFv = new CbKc();
      }
      //Расход доменного газа на обогрев (Оценочный, приведение "М-К")
      public CbKc Month { get; set; } // ст.м³ с начала месяца
      public CbKc Day { get; set; } // ст.м³ (1000кКал/м³)
      public CbKc Hour { get; set; } // ст.м³/час
      public CbKc UdFv { get; set; } // Удельный, ст.м³/тн. шихты в ф.в.
   }
}
