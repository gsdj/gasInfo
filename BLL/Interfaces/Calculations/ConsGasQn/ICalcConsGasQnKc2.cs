using BLL.Calculations.Base.Qn;
using BLL.Models.BaseModels.Characteristics.Gas;
using BLL.Models.BaseModels.General;
using BLL.Models.BaseModels.QcRc;

namespace BLL.Interfaces.Calculations.ConsGasQn
{
   public interface ICalcConsGasQnKc2 : ICalcConsGasQn<CbKc, QcRcKc2, CharacteristicsKG, ConsGasQn4000>
   {
      ICalcQcRc<QcRcKc2> CalcQcRcKc2 { get; }
   }
}
