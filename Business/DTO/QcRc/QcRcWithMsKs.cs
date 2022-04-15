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

   public class Consumption
   {
      public decimal Ms { get; set; }
      public decimal Ks { get; set; }
      protected decimal General { get; set; }
      public virtual decimal Value
      {
         get
         {
            //qcrcCpsPpk.Uvtp == 0 || charKg.Kc1.Characteristics.Qn == 0 ? 0 :
            return (Ms + Ks) == 0 ? General : Ms + Ks;
         }
         set
         {
            if (Ms == 0 && Ks == 0)
               General = value;
         }
      }
   }
   public class QcRcDefault2 : Consumption { }
   public class QcRcOnMultiplier2 : Consumption
   {
      public override decimal Value 
      {
         get 
         {
            return (Ms + Ks) == 0 ? General : (Ms + Ks) * 24; 
         }
         set 
         {
            if (Ms == 0 && Ks == 0)
               General = value;
         } 
      }
   }
}
