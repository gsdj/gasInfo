using DataAccess.Entities;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
   public class UnitOfWork : IUnitOfWork, IDisposable
   {
      private GasInfoDbContext db = new GasInfoDbContext();
      public void Save()
      {
         db.SaveChanges();
      }
      private bool disposed = false;
      public virtual void Dispose(bool disposing)
      {
         if (!this.disposed)
         {
            if (disposing)
            {
               db.Dispose();
            }
            this.disposed = true;
         }
      }
      public void Dispose()
      {
         Dispose(true);
         GC.SuppressFinalize(this);
      }


   }
}
