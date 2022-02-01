using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO.Characteristics.Quality
{
   public class QualityCharacteristics : QualityBase
   {
      public decimal Vc { get; set; }
      public decimal KgFv { get; set; }
      public decimal Density { get; set; }
      public decimal KgFh { get; set; }
   }
}
