namespace Business.Interfaces.BaseCalculations.Consumption
{
   public interface IUdConsDgFv
   {
      decimal Calc(decimal consDg, decimal consPg, decimal consFv);
   }
}
