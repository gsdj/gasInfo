using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
   public class AmmountCb : CokeBattery<int>, IEntity
   {
      public Guid Id { get; set; }
      public DateTime Date { get; set; }
      public Guid OutputMultipliersId { get; set; }
      public OutputMultipliers OutputMultipliers { get; set; }
   }
}
