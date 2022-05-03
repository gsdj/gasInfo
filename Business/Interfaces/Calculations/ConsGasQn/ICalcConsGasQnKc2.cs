using Business.DTO;
using Business.DTO.Consumption;
using Business.DTO.QcRc;

namespace Business.Interfaces.Calculations.ConsGasQn
{
   public interface ICalcConsGasQnKc2 : ICalcConsGasQn<ConsumptionKc2<decimal>, QcRcKc2, CharacteristicsKgDTO>
   {
      ICalcQcRc<QcRcKc2> CalcQcRcKc2 { get; }
   }
}
