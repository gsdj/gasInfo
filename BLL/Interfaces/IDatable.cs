using System;

namespace BLL.Interfaces
{
   public interface IDatable<T> where T : class
   {
      T GetItemByDate(DateTime Date);
   }
}
