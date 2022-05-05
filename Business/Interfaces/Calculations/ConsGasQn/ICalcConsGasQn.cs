using Business.BusinessModels.DataForCalculations;
using Business.Interfaces.BaseCalculations.Consumption;

namespace Business.Interfaces.Calculations.ConsGasQn
{
   public interface ICalcConsGasQn<TResult, TInputQcRc, TInputCGas, TGasQn>
   {
      IConsGasQn<TGasQn> ConsGasQn { get; }
      TResult Calc(TInputQcRc qcrc, TInputCGas cGas);
      TResult Calc(QcRcData data);
   }
}
