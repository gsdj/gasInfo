using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Entities
{
   public class TestOwnedType
   {
      public int Id { get; set; }
      public int Value1 { get; set; }
      public OT OT { get; set; }

   }

   public class OT
   {
      public string ValueStr1 { get; set; }
      public string ValueStr2 { get; set; }
   }
}
