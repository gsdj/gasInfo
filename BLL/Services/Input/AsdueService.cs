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
      private IUnitOfWork Db;
      public AsdueService(IUnitOfWork uof)
      {
         Db = uof;
      }
      public AsdueDTO GetItemByDate(DateTime Date)
      {
         return ToDTO(Db.Asdue.GetByDate(Date));
      }

      public IEnumerable<AsdueDTO> GetItemsByMonth(DateTime Date)
      {
         return Db.Asdue.GetPerMonth(Date.Year, Date.Month).Select(p => ToDTO(p));
      }

      public IEnumerable<AsdueDTO> GetItemsByNowMonth()
      {
         DateTime dateNow = DateTime.Now;
         return Db.Asdue.GetPerMonth(dateNow.Year, dateNow.Month).Select(p => ToDTO(p));
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

      public bool InsertOrUpdate(AsdueDTO entity)
      {
         Asdue asd = Db.Asdue.GetByDate(entity.Date) ?? new Asdue();
         try
         {
            asd.Date = entity.Date;
            asd.TecNorth = entity.TecNorth;
            asd.TecSouth = entity.TecSouth;
            asd.Gps2Gss1 = entity.Gps2Gss1;
            asd.Gps2Gss2 = entity.Gps2Gss2;
            asd.NaturalGasQn = entity.NaturalGasQn;
            asd.OutPkg = entity.OutPkg;

            if (asd.Id > 0)
            {
               Db.Asdue.Update(asd);
            }
            else
            {
               Db.Asdue.Create(asd);
            }
            return true;
         }
         catch (Exception ex)
         {
            return false;
         }
      }

      public IEnumerable<AsdueDTO> GetItemsByYear(int Year)
      {
         return Db.Asdue.GetPerYear(Year).Select(p => ToDTO(p));
      }

      public IEnumerable<AsdueDTO> GetItemsByNowYear()
      {
         int Year = DateTime.Now.Year;
         return Db.Asdue.GetPerYear(Year).Select(p => ToDTO(p));
      }
   }
}
