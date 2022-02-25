using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
   public class AmmountCbDTO : AmmountCb<int>
   {
      public DateTime Date { get; set; }
   }
}
