using BLL.Models.BaseModels.General;

namespace BLL.DTO
{
   public class ReportKgDTO : Entity
   {
      public decimal OutKgPko { get; set; }
      public decimal OutKgCb16 { get; set; }// => Math.Round((Kbs16 == 0 || KbsMk == 0) ? 0 : (OutKgKb18 * (Kbs16 / KbsMk)), 10);
      public decimal OutKgCb78 { get; set; }// =>=> Math.Round((Kbs78 == 0 || KbsMk == 0) ? 0 : (OutKgKb18 * (Kbs78 / KbsMk)), 10);
      public decimal OutKgCb18 { get; set; }//=> Math.Round((OutKgMk - OutKgPko), 10);
      public decimal OutKgMk { get; set; }
      public decimal KipSpr { get; set; }

      public decimal OutKgDryPkp { get; set; }
      public decimal OutKgDryCb16 { get; set; }//=> Math.Round((OutKgKb16 == 0 || ConsSuhKb16 == 0) ? 0 : (OutKgKb16 / ConsSuhKb16), 10);
      public decimal OutKgDryCb78 { get; set; }//=> Math.Round((OutKgKb78 == 0 || ConsSuhKb78 == 0) ? 0 : (OutKgKb78 / ConsSuhKb78), 10);
      public decimal OutKgDryMk { get; set; }//=> Math.Round((OutKgKb18 == 0 || TnConsSuh == 0) ? 0 : (OutKgKb18 / TnConsSuh), 10);

      public CbKc ConsumptionKc2 { get; set; }
      public CpsPpk ConsumptionCpsPpk { get; set; }
      public decimal ConsKgCpsPpkSum { get; set; }// => Math.Round((ConsKgSpo + ConsKgPkp + ConsKgUvtp), 10);
      public decimal ConsKgMk { get; set; }// => Math.Round((ConsKgKc2 + ConsKgCpsPpk), 10);
      public CbKc ConsumptionFvKc2 { get; set; }
      public decimal ConsFvKc2Sum { get; set; }
      public CpsPpk ConsumptionFvCpsPpk { get; set; }
      public decimal ConsFvCpsPpkSum { get; set; }
      public decimal ConsGsuf { get; set; }
      public decimal TradeGasChmk { get; set; }
   }
}
