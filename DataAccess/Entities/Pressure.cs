using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
   public class Pressure : IEntity
   {
      public Guid Id { get; set; }
      public DateTime Date { get; set; }
      public decimal Value { get; set; }
   }
}
