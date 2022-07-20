using Business.BusinessModels.BaseCalculations.Qn;
using Business.DTO.Models.Characteristics.Gas;
using Business.DTO.Models.General;
using Business.DTO.Models.QcRc;

namespace Business.Interfaces.Calculations.ConsGasQn
{
   public interface ICalcConsGasQnCpsPpk : ICalcConsGasQn<CpsPpk, CpsPpkQcRc, CharacteristicsKG, ConsGasQn4000>
   {

      ICalcQcRc<CpsPpkQcRc> CalcQcRcCpsPpk { get; }
   }
}
