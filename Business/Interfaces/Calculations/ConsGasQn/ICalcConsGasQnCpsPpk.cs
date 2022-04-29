using Business.DTO;
using Business.DTO.Consumption;
using Business.DTO.General;
using Business.DTO.QcRc;

namespace Business.Interfaces.Calculations.ConsGasQn
{
   public interface ICalcConsGasQnCpsPpk<T> : ICalcConsGasQn<CpsPpkConsumption, CpsPpkQcRc, CharacteristicsKgDTO>
   {
      //ICalcQcRc<QcRcCpsPpk> CalcQcRcCpsPpk { get; }
      ICalcQcRc<CpsPpkQcRc> CalcQcRcCpsPpk { get; }
   }
}
