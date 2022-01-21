using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
   public class PressureRepository : IRepository<Pressure>
   {
      public void Add(Pressure entity)
      {
         throw new NotImplementedException();
      }

      public Pressure FindById(Guid guid)
      {
         throw new NotImplementedException();
      }

      public IEnumerable<Pressure> GetPerMonth()
      {
         throw new NotImplementedException();
      }

      public IEnumerable<Pressure> GetPerMonth(int Year, int Month)
      {
         throw new NotImplementedException();
      }

      public IEnumerable<Pressure> GetPerYear()
      {
         throw new NotImplementedException();
      }

      public IEnumerable<Pressure> GetPerYear(int Year)
      {
         throw new NotImplementedException();
      }

      public void Remove(Pressure entity)
      {
         throw new NotImplementedException();
      }

      public void Update(Pressure entity)
      {
         throw new NotImplementedException();
      }
   }
}
