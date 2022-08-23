using BLL.Calculations.Base.Qn;
using BLL.Models.BaseModels.Characteristics.Gas;
using BLL.Models.BaseModels.General;
using BLL.Models.BaseModels.QcRc;

namespace BLL.Interfaces.Calculations.ConsGasQn
{
   public interface ICalcConsGasQnCpsPpk : ICalcConsGasQn<CpsPpk, CpsPpkQcRc, CharacteristicsKG, ConsGasQn4000>
   {

      ICalcQcRc<CpsPpkQcRc> CalcQcRcCpsPpk { get; }
   }
}
