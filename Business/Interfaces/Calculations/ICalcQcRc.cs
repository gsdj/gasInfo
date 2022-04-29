using Business.BusinessModels.DataForCalculations;

namespace Business.Interfaces.Calculations
{
   public interface ICalcQcRc<T>
   {
      T Calc(QcRcData data);
   }
}
