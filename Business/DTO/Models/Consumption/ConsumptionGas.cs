
namespace Business.DTO.Models.Consumption
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
            return (Ms + Ks) == 0 ? General : Ms + Ks;
         }
         set
         {
            if (Ms == 0 && Ks == 0)
               General = value;
         }
      }
   }
}
