using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
   public interface IJsonFileReader<T>
   {
      IEnumerable<T> Read(string path);
      IEnumerable<T> Read();
   }
}
