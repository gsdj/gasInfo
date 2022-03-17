using DataAccess.Entities.Characteristics;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
   public class SteamRepository : ISteamRepository
   {
      private GasInfoDbContext _context;
      private SteamJsonReader _reader;
      public SteamRepository(GasInfoDbContext context)
      {
         _context = context;
      }
      //public SteamRepository(SteamJsonReader reader)
      //{
      //   _reader = reader;
      //}
      //public IEnumerable<SteamCharacteristics> GetAll()
      //{
      //   return _reader.GetAllSteamCharacteristics();
      //}
      //public SteamCharacteristics GetByTemp(decimal temp)
      //{
      //   int tempRounded = Convert.ToInt32(Math.Round(temp, MidpointRounding.ToEven));
      //   return _reader.GetAllSteamCharacteristics().FirstOrDefault(p => p.Temp == tempRounded);
      //}
      public IEnumerable<SteamCharacteristics> GetAll()
      {
         return _context.SteamCharacteristics.AsNoTracking();
      }

      public SteamCharacteristics GetByTemp(decimal temp)
      {
         int tempRounded = Convert.ToInt32(Math.Round(temp, MidpointRounding.ToEven));
         return _context.SteamCharacteristics.AsNoTracking().FirstOrDefault(p => p.Temp == tempRounded);
      }
   }
}
