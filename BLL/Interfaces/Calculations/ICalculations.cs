using BLL.DataHelpers;
using System.Collections.Generic;

namespace BLL.Interfaces.Calculations
{
   public interface ICalculations<T>
   {
      IEnumerable<T> CalcEntities(EnumerableData data);
   }
}
