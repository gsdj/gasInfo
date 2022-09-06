using DA.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

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
      public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
      {
         return _dbSet.Where(predicate).ToList();
      }
      public virtual void Create(TEntity entity)
      {
         _dbSet.Add(entity);
         _context.SaveChanges();
      }

      public virtual TEntity GetById(int id)
      {
         return _dbSet.Find(id);
      }

      public virtual void Delete(TEntity entity)
      {
         _dbSet.Remove(entity);
         _context.SaveChanges();
      }

      public virtual void Update(TEntity entity)
      {
         _context.Entry(entity).State = EntityState.Modified;
         _context.SaveChanges();
      }

      public virtual IEnumerable<TEntity> GetAll()
      {
         return _dbSet.ToList();
      }
   }
}
