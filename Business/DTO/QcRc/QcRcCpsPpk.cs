using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO.QcRc
{
   public class QcRcCpsPpk
   {
      public QcRcCpsPpk()
      {
         Pko = new QcRcMsKsDefault();
      }
      public QcRcMsKsDefault Pko { get; set; }
      public decimal Uvtp { get; set; }
      public decimal Spo { get; set; }
      public decimal Gsuf { get; set; }
   }
}
