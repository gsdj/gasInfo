namespace BLL.Interfaces.BaseCalculations.Consumption
{
   public interface IConsPgCb
   {
      decimal Calc(decimal consDg, decimal consPgKc, decimal kcSum);
   }
}
