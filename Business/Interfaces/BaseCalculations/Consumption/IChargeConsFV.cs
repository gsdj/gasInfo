
namespace Business.Interfaces.BaseCalculations.Consumption
{
   public interface IChargeConsFV<T>
   {
      decimal Calc(int Cb, decimal CbCoef, decimal FvCoef);
   }
}
