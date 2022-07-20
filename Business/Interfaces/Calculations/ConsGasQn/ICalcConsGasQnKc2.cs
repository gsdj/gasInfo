using Business.BusinessModels.BaseCalculations.Qn;
using Business.DTO.Models.Characteristics.Gas;
using Business.DTO.Models.General;
using Business.DTO.Models.QcRc;

namespace Business.Interfaces.Calculations.ConsGasQn
{
   public interface ICalcConsGasQnKc2 : ICalcConsGasQn<CbKc, QcRcKc2, CharacteristicsKG, ConsGasQn4000>
   {
      ICalcQcRc<QcRcKc2> CalcQcRcKc2 { get; }
   }
}
