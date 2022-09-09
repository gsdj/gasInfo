using BLL.DTO.Input;
using BLL.Interfaces.Services.Input;
using DA.Entities;
using DA.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services.Input
{
   public class PressureService : IPressureService
   {
      private IGasGenericRepository<Pressure> PressureRep;
      public PressureService(IGasGenericRepository<Pressure> rep)
      {
         PressureRep = rep;
      }

      public PressureDTO GetItemByDate(DateTime Date)
      {
         var pressure = PressureRep.GetByDate(Date);
         return new PressureDTO
         {
            Date = pressure.Date,
            Value = pressure.Value,
         };
      }

      public IEnumerable<PressureDTO> GetItemsByMonth(DateTime Date)
      {
         return PressureRep.GetPerMonth(Date.Year, Date.Month).Select(p => ToDTO(p));
      }

      public IEnumerable<PressureDTO> GetItemsByNowMonth()
      {
         DateTime dateNow = DateTime.Now;
         return PressureRep.GetPerMonth(dateNow.Year, dateNow.Month).Select(p => ToDTO(p));
      }

      public bool InsertOrUpdate(PressureDTO entity)
      {
         try
         {
            Pressure pressure = new Pressure
            {
               Date = entity.Date,
               Value = entity.Value,
            };
            PressureRep.Create(pressure);
         }
         catch (Exception)
         {
            return false;
         }
         return true;
      }

      public IEnumerable<PressureDTO> GetItemsByYear(int Year)
      {
         return PressureRep.GetPerYear(Year).Select(p => ToDTO(p));
      }

      public IEnumerable<PressureDTO> GetItemsByNowYear()
      {
         int Year = DateTime.Now.Year;
         return PressureRep.GetPerYear(Year).Select(p => ToDTO(p));
      }

      private PressureDTO ToDTO(Pressure pressure)
      {
         return new PressureDTO
         {
            Date = pressure.Date,
            Value = pressure.Value,
            ValuePa = pressure.Value * 133.3224m,
         };
      }
   }
}
