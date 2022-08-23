using DA.Interfaces;
using System;

namespace DA.Entities
{
   public class DgPgChmkEb : IGasEntity
   {
      public Guid Id { get; set; }
      public DateTime Date { get; set; }
      public int ConsDgCb1 { get; set; }
      public int ConsDgCb2 { get; set; }
      public int ConsDgCb3 { get; set; }
      public int ConsDgCb4 { get; set; }
      public int ConsPgGru1 { get; set; }
      public int ConsPgGru2 { get; set; }
   }
}
