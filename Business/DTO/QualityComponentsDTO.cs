using Business.DTO.Characteristics.Quality;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
   public class QualityComponentsDTO
   {
      public DateTime Date { get; set; }
      public QualityComponents Kc1 { get; set; }
      public QualityComponents Kc2 { get; set; }
   }
}
