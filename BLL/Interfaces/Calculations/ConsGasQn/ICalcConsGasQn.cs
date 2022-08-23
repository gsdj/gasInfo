using BLL.DataHelpers;
using BLL.Interfaces.BaseCalculations.Consumption;

namespace BLL.Interfaces.Calculations.ConsGasQn
{
   public interface ICalcConsGasQn<TResult, TInputQcRc, TInputCGas, TGasQn>
   {
      IConsGasQn<TGasQn> ConsGasQn { get; }
      TResult Calc(TInputQcRc qcrc, TInputCGas cGas);
      TResult Calc(QcRcData data);
   }
}
