using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DA.Interfaces
{
   public interface IGasGenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IGasEntity
   {
      /// <summary>
      /// Returns data for the specified month
      /// </summary>
      /// <param name="Year"></param>
      /// <param name="Month"></param>
      /// <returns></returns>
      IEnumerable<TEntity> GetPerMonth(int Year, int Month);
      /// <summary>
      /// Returns data for the specified year
      /// </summary>
      /// <param name="Year"></param>
      /// <returns></returns>
      IEnumerable<TEntity> GetPerYear(int Year);
      TEntity GetByDate(DateTime Date);

   }
}
