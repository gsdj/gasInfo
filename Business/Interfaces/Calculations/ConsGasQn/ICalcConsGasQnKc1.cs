using Business.DTO;
using Business.DTO.Consumption;
using Business.DTO.QcRc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.Calculations.ConsGasQn
{
   public interface ICalcConsGasQnKc1<T> : ICalcConsGasQn<ConsumptionKc1<decimal>, QcRcKc1, CharacteristicsDgDTO>
   {
      ICalcQcRc<QcRcKc1> CalcQcRcKc1 { get; }
   }
}
