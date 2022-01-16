using DataAccess.Entities.Characteristics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
   public class CharacteristicsKgAll : IEntity
   {
      public Guid Id { get; set; }
      public DateTime Date { get; set; }
      public KG Kc1 { get; set; }
      public KG Kc2 { get; set; }
      public CharacteristicsKgAll()
      {
         Kc1 = new KG();
         Kc2 = new KG();
      }
   }
}
