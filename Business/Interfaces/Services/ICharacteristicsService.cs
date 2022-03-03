using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.Services
{
   public interface ICharacteristicsService<T> : IWritable<T>, IMonthable<T>, IDatable<T> where T : class
   {
   }
}
