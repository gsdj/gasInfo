using Business.DTO;
using Business.DTO.General;
using Business.DTO.QcRc;

namespace Business.Interfaces.Calculations.ConsGasQn
{
   public interface ICalcConsGasQnKc1 : ICalcConsGasQn<CbKc, QcRcKc1, CharacteristicsDgDTO>
   {
      ICalcQcRc<QcRcKc1> CalcQcRcKc1 { get; }
   }
}
