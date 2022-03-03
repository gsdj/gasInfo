using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
   public interface IWritable<T> where T: class
   {
      void Insert(T entity);
      void Upsert(T entity);
   }
}
