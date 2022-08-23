namespace BLL.Interfaces.BaseCalculations.Consumption
{
   public interface IConsGasQn<T>
   {
      decimal Calc(decimal qcrc, decimal qn);
   }
}
