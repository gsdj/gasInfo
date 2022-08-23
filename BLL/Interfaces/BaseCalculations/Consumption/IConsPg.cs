namespace BLL.Interfaces.BaseCalculations.Consumption
{
   public interface IConsPg
   {
      decimal Calc(decimal cons, decimal PPa, decimal pressure, decimal temp);
   }
}
