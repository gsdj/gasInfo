using System.Collections.Generic;

namespace DA.Interfaces
{
   public interface IJsonFileReader<T>
   {
      IEnumerable<T> Read(string path);
      IEnumerable<T> Read();
   }
}
