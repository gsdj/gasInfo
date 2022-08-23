using BLL.Models.BaseModels.General;

namespace BLL.DTO.Input
{
   public class DgPgChmkEbDTO : Entity
   {
      public DgPgChmkEbDTO()
      {
         ConsumptionDgKc1 = new CbKc();
         ConsumptionPgGru = new Gru();
      }
      public CbKc ConsumptionDgKc1 { get; set; }
      public Gru ConsumptionPgGru { get; set; }
   }
}
