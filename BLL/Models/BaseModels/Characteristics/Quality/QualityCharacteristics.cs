using BLL.Models.BaseModels.General;

namespace BLL.Models.BaseModels.Characteristics.Quality
{
   public class QualityCharacteristics : Entity
   {
      public QualityCharacteristics()
      {
         Kc1 = new Characteristics();
         Kc2 = new Characteristics();
      }
      public Characteristics Kc1 { get; set; }
      public Characteristics Kc2 { get; set; }
   }
}
