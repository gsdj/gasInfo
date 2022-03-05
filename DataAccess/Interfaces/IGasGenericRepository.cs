using DataAccess.Entities;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
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
      IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate);

   }

   public interface IGenRepQuery<TEntity> where TEntity : class, IGasEntity
   {
      IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
   }
}
