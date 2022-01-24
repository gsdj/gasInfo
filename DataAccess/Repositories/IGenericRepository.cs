using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
   public interface IGenericRepository<TEntity> where TEntity: class, IEntity
   {
      /// <summary>
      /// Returns data for the current month
      /// </summary>
      /// <returns></returns>
      IEnumerable<TEntity> GetPerMonth();
      /// <summary>
      /// Returns data for the specified month
      /// </summary>
      /// <param name="Year"></param>
      /// <param name="Month"></param>
      /// <returns></returns>
      IEnumerable<TEntity> GetPerMonth(int Year, int Month);
      /// <summary>
      /// Returns data for the current year
      /// </summary>
      /// <returns></returns>
      IEnumerable<TEntity> GetPerYear();
      /// <summary>
      /// Returns data for the specified year
      /// </summary>
      /// <param name="Year"></param>
      /// <returns></returns>
      IEnumerable<TEntity> GetPerYear(int Year);
      TEntity FindById(Guid guid);
      void Add(TEntity entity);
      void Remove(TEntity entity);
      void Update(TEntity entity);
   }
}
