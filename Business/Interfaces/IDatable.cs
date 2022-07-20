using System;

namespace Business.Interfaces
{
   public interface IDatable<T> where T : class
   {
      T GetItemByDate(DateTime Date);
   }
}
