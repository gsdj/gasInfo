using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DA.Interfaces
{
   public interface IGenericRepository<TEntity> where TEntity: class, IEntity
   {
      IEnumerable<TEntity> GetAll();
      TEntity GetById(int id);
      void Create(TEntity entity);
      void Delete(TEntity entity);
      void Update(TEntity entity);
      IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
   }
}
