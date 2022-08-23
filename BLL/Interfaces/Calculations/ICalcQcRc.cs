using BLL.DataHelpers;
using BLL.Interfaces.BaseCalculations;

namespace BLL.Interfaces.Calculations
{
   public interface ICalcQcRc<T>
   {
      IQcRc QcRc { get; }
      T Calc(QcRcData data);
   }
}
