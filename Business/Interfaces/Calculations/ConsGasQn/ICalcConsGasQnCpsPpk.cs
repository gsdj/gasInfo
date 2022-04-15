using Business.DTO;
using Business.DTO.Consumption;
using Business.DTO.QcRc;

namespace Business.Interfaces.Calculations.ConsGasQn
{
   public interface ICalcConsGasQnCpsPpk<T> : ICalcConsGasQn<ConsumptionCpsPpk, QcRcCpsPpk, CharacteristicsKgDTO>
   {
      ICalcQcRc<QcRcCpsPpk> CalcQcRcCpsPpk { get; }
   }
}
