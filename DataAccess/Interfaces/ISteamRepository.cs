using DataAccess.Entities.Characteristics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
   public interface ISteamRepository
   {
      SteamCharacteristics GetByTemp(decimal temp);
      IEnumerable<SteamCharacteristics> GetAll();
   }
}
