using BLL.Models.BaseModels.General;

namespace BLL.DTO
{
   public class DensityDTO : Entity
   {
      public DensityDTO()
      {
         Cu = new Cu();
         Kc2 = new CbKc();
         CpsPpk = new CpsPpk();
         Kc1 = new CbKc();
      }
      public Cu Cu { get; set; }
      public CbKc Kc2 { get; set; }
      public CpsPpk CpsPpk { get; set; }
      public decimal Gsuf { get; set; }
      public CbKc Kc1 { get; set; }
   }
}
