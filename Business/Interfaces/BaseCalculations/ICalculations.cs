using System.Collections.Generic;

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
