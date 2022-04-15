﻿
namespace Business.DTO.Consumption
{
   public class ConsumptionGas
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
   public class QcRcDefault2 : ConsumptionGas { }
   public class QcRcOnMultiplier2 : ConsumptionGas
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