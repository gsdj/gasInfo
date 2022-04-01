using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO.QcRc
{
   public class QcRcMsKsDefault
   {
      public decimal Ms { get; set; }
      public decimal Ks { get; set; }
      public virtual decimal Value
      {
         get { return (this.Ms + this.Ks); }
      }
   }
   public class QcRcMsKsOnMultiplier : QcRcMsKsDefault
   {
      public override decimal Value
      {
         get { return (this.Ms + this.Ks) * 24; }
      } 
   }
}
