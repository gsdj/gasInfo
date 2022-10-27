using BLL.DataHelpers;
using System.Collections.Generic;

namespace BLL.Interfaces.Calculations
{
   public interface ICalculations<T> : ICalculation<T> where T : class
   {
      IEnumerable<T> CalcEntities(EnumerableData data);
   }
}
