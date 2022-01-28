using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities.Characteristics
{
   public class SteamCharacteristics
   {
      public decimal PPa { get; set; }
      public decimal PKg { get; set; }
      //Содержание водяных паров в 1 м³ насыщенного газа, f кг/нм³
      public decimal Fkg { get; set; }
      //относительная влажность φ
      public decimal Rh { get; set; }
   }
}
