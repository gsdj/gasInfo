using Business.BusinessModels.DataForCalculations;
using System.Collections.Generic;

namespace Business.Interfaces.Calculations
{
   public interface ICalculations<T>
   {
      IEnumerable<T> CalcEntities(EnumerableData data);
   }
}
