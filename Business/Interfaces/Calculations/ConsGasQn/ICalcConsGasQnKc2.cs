using Business.BusinessModels.BaseCalculations.Qn;
using Business.DTO;
using Business.DTO.General;
using Business.DTO.QcRc;

namespace Business.Interfaces.Calculations.ConsGasQn
{
   public interface ICalcConsGasQnKc2 : ICalcConsGasQn<CbKc, QcRcKc2, CharacteristicsKgDTO, ConsGasQn4000>
   {
      ICalcQcRc<QcRcKc2> CalcQcRcKc2 { get; }
   }
}
