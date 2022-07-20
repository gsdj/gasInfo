using Business.DTO.Models.General;

namespace Business.DTO
{
   public class DensityDTO : Entity
   {
      public Cu Cu { get; set; }
      public CbKc Kc2 { get; set; }
      public CpsPpk CpsPpk { get; set; }
      public decimal Gsuf { get; set; }
      public CbKc Kc1 { get; set; }
   }
}
