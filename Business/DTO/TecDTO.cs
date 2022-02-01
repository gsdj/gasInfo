using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
   public class TecDTO
   {
      public DateTime Date { get; set; }

      public decimal Chmk { get; set; }

      public decimal TecNorth { get; set; }

      public decimal TecSouth { get; set; }

      public decimal TecSum { get; set; }

      public decimal ChmkTecSum { get; set; }

      public decimal ChmkTecPerHour { get; set; }
   }
}
