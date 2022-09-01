using DA.Interfaces;
using System;

namespace DA.Entities
{
   public class QualityAll : IGasEntity
   {
      public QualityAll()
      {
         Kc1 = new Quality();
         Kc2 = new Quality();
      }
      public int Id { get; set; }
      public DateTime Date { get; set; }
      public Quality Kc1 { get; set; }
      public Quality Kc2 { get; set; }
   }
}
