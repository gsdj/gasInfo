using BLL.Calculations.Base.Qn;
using BLL.Models.BaseModels.Characteristics.Gas;
using BLL.Models.BaseModels.General;
using BLL.Models.BaseModels.QcRc;

namespace BLL.Interfaces.Calculations.ConsGasQn
{
   public interface ICalcConsGasQnKc1 : ICalcConsGasQn<CbKc, QcRcKc1, CharacteristicsDG, ConsGasQn1000>
   {
      ICalcQcRc<QcRcKc1> CalcQcRcKc1 { get; }
   }

}
