using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
   public class Asdue : IEntity
   {
      public Guid Id { get; set; }
      public DateTime Date { get; set; }
      public decimal TecNorth { get; set; }
      public decimal TecSouth { get; set; }
      public decimal Gps2Gss1 { get; set; }
      public decimal Gps2Gss2 { get; set; }
      public decimal NaturalGasQn { get; set; }
      public decimal OutPkg { get; set; }
   }
}
