using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
   public interface IGenericRepository<TEntity> where TEntity: class, IEntity
   {
      TEntity FindById(Guid guid);
      void Create(TEntity entity);
      void Delete(TEntity entity);
      void Update(TEntity entity);
   }
}
