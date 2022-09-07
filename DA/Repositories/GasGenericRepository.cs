using DA.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DA.Repositories
{
   public class GasGenericRepository<TEntity> : EFGenericRepository<TEntity>, IGasGenericRepository<TEntity> where TEntity : class, IGasEntity
   {
      public GasGenericRepository(GasInfoDbContext context) : base(context) { }

      public TEntity GetByDate(DateTime Date)
      {
         return _dbSet.Find(Date);
      }

      public IEnumerable<TEntity> GetPerMonth(int Year, int Month)
      {
         DateTime FirstDate = new DateTime(Year, Month, 1);
         DateTime LastDate = new DateTime(Year, Month, DateTime.DaysInMonth(Year, Month));
         return _dbSet.Where(p => p.Date >= FirstDate && p.Date <= LastDate);
      }

      public IEnumerable<TEntity> GetPerYear(int Year)
      {
         DateTime FirstDate = new DateTime(Year, 1, 1);
         DateTime LastDate = new DateTime(Year, 12, 31);
         return _dbSet.Where(p => p.Date >= FirstDate && p.Date <= LastDate);
      }
   }
}
