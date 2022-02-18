using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
   public class DgPgChmkEbDTO
   {
      public DateTime Date { get; set; }
      public int ConsDgCb1 { get; set; } = 0;
      public int ConsDgCb2 { get; set; } = 0;
      public int ConsDgCb3 { get; set; } = 0;
      public int ConsDgCb4 { get; set; } = 0;
      public int ConsDgKc1 { get; set; }// => ConsDgCb1 + ConsDgCb2 + ConsDgCb3 + ConsDgCb4;
      public int ConsPgGru1 { get; set; } = 0;
      public int ConsPgGru2 { get; set; } = 0;
      public int ConsPgUpc { get; set; }// => ConsPgGru1 + ConsPgGru2;
   }
}
