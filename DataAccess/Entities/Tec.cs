using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
   public class Tec : IEntity
   {
      public Guid Id { get; set; }
      public DateTime Date { get; set; }
      public decimal Chmk { get; set; }
      public decimal TecNorth { get; set; }
      public decimal TecSouth { get; set; }
   }
}
