using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
   public class GasGenericRepository<TEntity> : EFGenericRepository<TEntity>, IGasGenericRepository<TEntity> where TEntity : class, IGasEntity
   {
      protected int YearNow;
      protected int MonthNow;
      public GasGenericRepository(GasInfoDbContext context) : base(context)
      {
         YearNow = DateTime.Now.Year;
         MonthNow = DateTime.Now.Month;
      }

      public TEntity GetByDate(DateTime Date)
      {
         return _dbSet.Find(Date);
      }

      public IEnumerable<TEntity> GetPerMonth()
      {
         DateTime FirstDate = new DateTime(YearNow, MonthNow, 1);
         DateTime LastDate = new DateTime(YearNow, MonthNow, DateTime.DaysInMonth(YearNow, MonthNow));
         return _dbSet.Where(p => p.Date >= FirstDate && p.Date <= LastDate);
      }

      public IEnumerable<TEntity> GetPerMonth(int Year, int Month)
      {
         DateTime FirstDate = new DateTime(Year, Month, 1);
         DateTime LastDate = new DateTime(Year, Month, DateTime.DaysInMonth(Year, Month));
         return _dbSet.Where(p => p.Date >= FirstDate && p.Date <= LastDate);
      }

      public IEnumerable<TEntity> GetPerYear()
      {
         DateTime FirstDate = new DateTime(YearNow, 1, 1);
         DateTime LastDate = new DateTime(YearNow, 12, DateTime.DaysInMonth(YearNow, 12));
         return _dbSet.Where(p => p.Date >= FirstDate && p.Date <= LastDate);
      }

      public IEnumerable<TEntity> GetPerYear(int Year)
      {
         DateTime FirstDate = new DateTime(Year, 1, 1);
         DateTime LastDate = new DateTime(Year, 12, DateTime.DaysInMonth(Year, 12));
         return _dbSet.Where(p => p.Date >= FirstDate && p.Date <= LastDate);
      }
   }
}
