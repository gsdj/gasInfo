using BLL.Models.BaseModels.General;

namespace BLL.Models.BaseModels.Production
{
   public class CokeCbDry : CbAll
   {
      public decimal Cb1_6 => Kc1.Cb1 + Kc1.Cb2 + Kc1.Cb3 + Kc1.Cb4 + Kc2.Cb1 + Kc2.Cb2;
      public decimal Cb7_8 => Kc2.Cb3 + Kc2.Cb4;
      public decimal TnDry => Cb1_6 + Cb7_8;
      public decimal KpeDry { get; set; }
   }
}
