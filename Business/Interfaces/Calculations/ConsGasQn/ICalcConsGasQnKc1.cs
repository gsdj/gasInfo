using Business.DTO;
using Business.DTO.Consumption;
using Business.DTO.QcRc;

namespace Business.Interfaces.Calculations.ConsGasQn
{
   public interface ICalcConsGasQnKc1 : ICalcConsGasQn<ConsumptionKc1<decimal>, QcRcKc1, CharacteristicsDgDTO>
   {
      ICalcQcRc<QcRcKc1> CalcQcRcKc1 { get; }
   }
}
