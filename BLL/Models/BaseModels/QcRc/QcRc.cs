using BLL.Models.BaseModels.Consumption;

namespace BLL.Models.BaseModels.QcRc
{
   public class QcRcDefault : ConsumptionGas { }
   public class QcRcOnMultiplier : ConsumptionGas
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
