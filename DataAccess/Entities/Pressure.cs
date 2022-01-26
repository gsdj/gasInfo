using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
   public class Pressure : IGasEntity
   {
      public Guid Id { get; set; }
      public DateTime Date { get; set; }
      public decimal Value { get; set; }
   }
}
