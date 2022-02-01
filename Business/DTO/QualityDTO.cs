using Business.DTO.Characteristics.Quality;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
   public class QualityDTO
   {
      public DateTime Date { get; set; }
      public QualityCharacteristics Kc1 { get; set; }
      public QualityCharacteristics Kc2 { get; set; }
   }
}
