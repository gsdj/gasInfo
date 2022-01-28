using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Interfaces
{
   public interface IEntitiesCalculations<T> where T : class
   {
      IEnumerable<T> Calc();
   }
}
