using DataAccess.Entities.Characteristics;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
   public class CharacteristicsDgAll : IGasEntity
   {
      public Guid Id { get; set; }
      public DateTime Date { get; set; }
      public DG Kc1 { get; set; }
      public DG Kc2 { get; set; }
   }
}
