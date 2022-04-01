namespace Business.Interfaces.BaseCalculations
{
   public interface IConsPg
   {
      decimal Calc(decimal cons, decimal PPa, decimal pressure, decimal temp);
   }
}
