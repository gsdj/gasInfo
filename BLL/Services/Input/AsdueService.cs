using BLL.DTO.Input;
using BLL.Interfaces.Services.Input;
using DA.Entities;
using DA.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services.Input
{
   public class AsdueService : IAsdueService
   {
      private IUnitOfWork db;
      public AsdueService(IUnitOfWork uof)
      {
         db = uof;
      }
      public AsdueDTO GetItemByDate(DateTime Date)
      {
         throw new NotImplementedException();
      }

      public IEnumerable<AsdueDTO> GetItemsByMonth(DateTime Date)
      {
         return db.Asdue.GetPerMonth(Date.Year, Date.Month).Select(p => ToDTO(p));
      }

      public IEnumerable<AsdueDTO> GetItemsByNowMonth()
      {
         DateTime dateNow = DateTime.Now;
         return db.Asdue.GetPerMonth(dateNow.Year, dateNow.Month).Select(p => ToDTO(p));
      }

      private AsdueDTO ToDTO(Asdue asdue)
      {
         return new AsdueDTO
         {
            Date = asdue.Date,
            TecNorth = asdue.TecNorth,
            TecSouth = asdue.TecSouth,
            Gps2Gss1 = asdue.Gps2Gss1,
            Gps2Gss2 = asdue.Gps2Gss2,
            NaturalGasQn = asdue.NaturalGasQn,
            OutPkg = asdue.OutPkg,
            StmDay = asdue.TecNorth + asdue.TecSouth + asdue.Gps2Gss2 + asdue.Gps2Gss1,
         };
      }

      public bool InsertOrUpsert(AsdueDTO entity)
      {
         throw new NotImplementedException();
      }

      public IEnumerable<AsdueDTO> GetItemsByYear(int Year)
      {
         return db.Asdue.GetPerYear(Year).Select(p => ToDTO(p));
      }

      public IEnumerable<AsdueDTO> GetItemsByNowYear()
      {
         int Year = DateTime.Now.Year;
         return db.Asdue.GetPerYear(Year).Select(p => ToDTO(p));
      }
   }
}
