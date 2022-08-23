using System;

namespace DA.Interfaces
{
   public interface IGenericRepository<TEntity> where TEntity: class, IEntity
   {
      TEntity FindById(Guid guid);
      void Create(TEntity entity);
      void Delete(TEntity entity);
      void Update(TEntity entity);
   }
}
