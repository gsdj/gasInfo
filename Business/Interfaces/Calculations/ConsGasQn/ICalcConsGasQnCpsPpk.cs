using Business.DTO;
using Business.DTO.General;

namespace Business.Interfaces.Calculations.ConsGasQn
{
   public interface ICalcConsGasQnCpsPpk : ICalcConsGasQn<CpsPpk, CpsPpkQcRc, CharacteristicsKgDTO>
   {
      ICalcQcRc<CpsPpkQcRc> CalcQcRcCpsPpk { get; }
   }
}
