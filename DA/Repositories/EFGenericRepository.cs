using DA.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace DA.Repositories
{
   public class EFGenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IEntity
   {
      protected GasInfoDbContext _context;
      internal DbSet<TEntity> _dbSet;

      public EFGenericRepository(GasInfoDbContext context)
      {
         _context = context;
         _dbSet = context.Set<TEntity>();
      }
      public virtual void Create(TEntity entity)
      {
         _dbSet.Add(entity);
      }

      public virtual TEntity FindById(Guid guid)
      {
         return _dbSet.Find(guid);
      }

      public virtual void Delete(TEntity entity)
      {
         _dbSet.Remove(entity);
      }

      public virtual void Update(TEntity entity)
      {
         _context.Entry(entity).State = EntityState.Modified;
      }
   }
}
