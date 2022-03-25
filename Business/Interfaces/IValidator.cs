using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
   public interface IValidator<T> where T : class  
   {
      public bool Validate(T entity);
   }
}
