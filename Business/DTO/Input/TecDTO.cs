using Business.DTO.Models.General;

namespace Business.DTO.Input
{
   public class TecDTO : Entity
   {
      public decimal Chmk { get; set; }
      public decimal TecNorth { get; set; }
      public decimal TecSouth { get; set; }
      public decimal TecSum { get; set; }
      public decimal ChmkTecSum { get; set; }
      public decimal ChmkTecPerHour { get; set; }
   }
}
