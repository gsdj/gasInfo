using Business.BusinessModels.DataForCalculations;

namespace Business.Interfaces.Calculations
{
   public interface ICalcQcRc<T>
   {
      //IQcRc QcRc { get; } ?
      T Calc(QcRcData data);
   }
}
