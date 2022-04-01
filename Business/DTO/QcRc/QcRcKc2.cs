using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO.QcRc
{
   public class QcRcKc2
   {
      public QcRcKc2()
      {
         Cb7 = new QcRcMsKsOnMultiplier();
         Cb8 = new QcRcMsKsOnMultiplier();
      }
      public decimal Cb5 { get; set; }
      public decimal Cb6 { get; set; }
      public QcRcMsKsOnMultiplier Cb7 { get; set; }
      public QcRcMsKsOnMultiplier Cb8 { get; set; }
   }
}
