using Business.BusinessModels.DataForCalculations;
using Business.Interfaces.BaseCalculations;

namespace Business.Interfaces.Calculations
{
   public interface ICalcQcRc<T>
   {
      IQcRc QcRc { get; }
      T Calc(QcRcData data);
   }
}
