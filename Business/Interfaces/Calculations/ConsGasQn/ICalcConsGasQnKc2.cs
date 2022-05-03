using Business.DTO;
using Business.DTO.General;
using Business.DTO.QcRc;

namespace Business.Interfaces.Calculations.ConsGasQn
{
   public interface ICalcConsGasQnKc2 : ICalcConsGasQn<CbKc, QcRcKc2, CharacteristicsKgDTO>
   {
      ICalcQcRc<QcRcKc2> CalcQcRcKc2 { get; }
   }
}
