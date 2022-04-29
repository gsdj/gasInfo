using Business.DTO;
using Business.DTO.General;

namespace Business.Interfaces.Calculations.ConsGasQn
{
   public interface ICalcConsGasQnCpsPpk<T> : ICalcConsGasQn<CpsPpk, CpsPpkQcRc, CharacteristicsKgDTO>
   {
      //ICalcQcRc<QcRcCpsPpk> CalcQcRcCpsPpk { get; }
      ICalcQcRc<CpsPpkQcRc> CalcQcRcCpsPpk { get; }
   }
}
