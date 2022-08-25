using BLL.DTO.Input;
using BLL.Interfaces.Service.Input;
using DA.Entities;
using System;
using System.Collections.Generic;

namespace BLL.Services.Input
{
   public class AmmountCbService : IAmmountCbService
   {
      public AmmountCbDTO GetItemByDate(DateTime Date)
      {
         throw new NotImplementedException();
      }

      public IEnumerable<AmmountCbDTO> GetItemsByMonth(DateTime Date)
      {
         throw new NotImplementedException();
      }

      public IEnumerable<AmmountCbDTO> GetItemsByNowMonth()
      {
         throw new NotImplementedException();
      }

      public IEnumerable<AmmountCbDTO> GetItemsByNowYear()
      {
         throw new NotImplementedException();
      }

      public IEnumerable<AmmountCbDTO> GetItemsByYear(int Year)
      {
         throw new NotImplementedException();
      }

      public bool InsertOrUpsert(AmmountCbDTO entity)
      {
         throw new NotImplementedException();
      }
      private AmmountCbDTO ToDTO(AmmountCb cb)
      {
         return new AmmountCbDTO
         {
            //Date = cb.Date,
            //Cb1 = asdue.TecNorth,
            //Cb2 = asdue.TecNorth,
            //Cb3 = asdue.TecNorth,
            //Cb4 = asdue.TecNorth,
            //Cb5 = asdue.TecNorth,
            //Cb6 = asdue.TecNorth,
            //Cb7 = asdue.TecNorth,
            //Cb8 = asdue.TecNorth,
            //PKP = cb.PKP
         };
      }
   }
}
