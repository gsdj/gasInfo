namespace BLL.Interfaces.BaseCalculations.Consumption
{
   public interface ISpecificConsDgFv
   {
      decimal Calc(decimal consDg, decimal consPg, decimal consFv);
   }
}
