using Business.BusinessModels.BaseCalculations.Qn;
using Business.DTO.Models.Characteristics.Gas;
using Business.DTO.Models.General;
using Business.DTO.Models.QcRc;

namespace Business.Interfaces.Calculations.ConsGasQn
{
   public interface ICalcConsGasQnKc1 : ICalcConsGasQn<CbKc, QcRcKc1, CharacteristicsDG, ConsGasQn1000>
   {
      ICalcQcRc<QcRcKc1> CalcQcRcKc1 { get; }
   }
}
