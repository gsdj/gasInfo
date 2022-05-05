using Business.BusinessModels.BaseCalculations.Qn;
using Business.DTO;
using Business.DTO.General;

namespace Business.Interfaces.Calculations.ConsGasQn
{
   public interface ICalcConsGasQnCpsPpk : ICalcConsGasQn<CpsPpk, CpsPpkQcRc, CharacteristicsKgDTO, ConsGasQn4000>
   {

      ICalcQcRc<CpsPpkQcRc> CalcQcRcCpsPpk { get; }
   }
}
