using Business.BusinessModels.DataForCalculations;

namespace Business.Interfaces.Calculations.ConsGasQn
{
   public interface ICalcConsGasQn<TResult, TInputQcRc, TInputCGas>
   {
      TResult Calc(TInputQcRc qcrc, TInputCGas cGas);
      TResult Calc(QcRcData data);
   }
}
