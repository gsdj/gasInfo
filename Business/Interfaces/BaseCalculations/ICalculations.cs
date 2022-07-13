using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.BaseCalculations
{
   public interface ICalculations<TInput, TOutput>
   {
      IEnumerable<TOutput> CalcEntities(IEnumerable<TInput> data);  
   }
   public interface ICalculation<TInput, TOutput>
   {
      TOutput CalcEntity(TInput data);
   }
}
