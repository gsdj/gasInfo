namespace Business.Interfaces.BaseCalculations
{
   public interface ISpoPerKus<T>
   {
      decimal Calc(decimal Pkp, decimal coefPkp, decimal CoefPeka);
   }
}
