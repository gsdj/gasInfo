using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
   public class QualityAll : IGasEntity
   {
      public QualityAll()
      {
         Kc1 = new Quality();
         Kc2 = new Quality();
      }
      public Guid Id { get; set; }
      public DateTime Date { get; set; }
      public Quality Kc1 { get; set; }
      public Quality Kc2 { get; set; }
   }
}
