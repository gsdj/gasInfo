using Business.DTO;
using Business.Interfaces.Services.Input;
using DataAccess.Entities;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Services.Input
{
   public class DevicesKipService : IDevicesKipService
   {
      IUnitOfWork db;
      public DevicesKipService(IUnitOfWork uof)
      {
         db = uof;
      }
      public DevicesKipDTO GetItemByDate(DateTime Date)
      {
         throw new NotImplementedException();
      }

      public IEnumerable<DevicesKipDTO> GetItemsByMonth(DateTime Date)
      {
         return db.DevicesKip.GetPerMonth(Date.Year, Date.Month).Select(p => ToDTO(p));
      }

      public IEnumerable<DevicesKipDTO> GetItemsByNowMonth()
      {
         DateTime dateNow = DateTime.Now;
         return db.DevicesKip.GetPerMonth(dateNow.Year,dateNow.Month).Select(p => ToDTO(p));
      }

      private DevicesKipDTO ToDTO(DevicesKip kip)
      {
         return new DevicesKipDTO
         {
            Date = kip.Date,
            Kc1 =
            {
               Cb1 =
               {
                  Pressure = kip.Cb1.Pressure,
                  Consumption = { Value = kip.Cb1.Consumption },
                  Temperature = kip.Cb1.Temperature,
               },
               Cb2 =
               {
                  Pressure = kip.Cb2.Pressure,
                  Consumption = { Value = kip.Cb2.Consumption },
                  Temperature = kip.Cb2.Temperature,
               },
               Cb3 =
               {
                  Pressure = kip.Cb3.Pressure,
                  Consumption = { Value = kip.Cb3.Consumption },
                  Temperature = kip.Cb3.Temperature,
               },
               Cb4 =
               {
                  Pressure = kip.Cb4.Pressure,
                  Consumption = { Value = kip.Cb4.Consumption },
                  Temperature = kip.Cb4.Temperature,
               },
            },
            Kc2 =
            {
               Cb1 =
               {
                  Pressure = kip.Cb5.Pressure,
                  Consumption = { Value = kip.Cb5.Consumption },
                  Temperature = kip.Cb5.Temperature,
                  TempBeforeHeating = kip.Cb5.TempBeforeHeating,
               },
               Cb2 =
               {
                  Pressure = kip.Cb6.Pressure,
                  Consumption = { Value = kip.Cb6.Consumption },
                  Temperature = kip.Cb6.Temperature,
                  TempBeforeHeating = kip.Cb6.TempBeforeHeating,
               },
               Cb3 =
               {
                  Pressure = kip.Cb7.Pressure,
                  Consumption =
                  {
                     Ms = kip.Cb7.ConsumptionMs,
                     Ks = kip.Cb7.ConsumptionKs
                  },
                  Temperature = kip.Cb7.Temperature,
                  TempBeforeHeating = kip.Cb7.TempBeforeHeating
               },
               Cb4 =
               {
                  Pressure = kip.Cb8.Pressure,
                  Consumption =
                  {
                     Ms = kip.Cb8.ConsumptionMs,
                     Ks = kip.Cb8.ConsumptionKs
                  },
                  Temperature = kip.Cb8.Temperature,
                  TempBeforeHeating = kip.Cb8.TempBeforeHeating
               },
            },
            Cu =
            {
               Cu1 =
               {
                  Pressure = kip.Cu1.Pressure,
                  Consumption = { Value = kip.Cu1.Consumption },
                  Temperature = kip.Cu1.Temperature,
               },
               Cu2 =
               {
                  Pressure = kip.Cu2.Pressure,
                  Consumption = { Value = kip.Cu2.Consumption },
                  Temperature = kip.Cu2.Temperature,
               },
            },
            CpsPpk =
            {
               Pko =
               {
                  Pkp =
                  {
                     Pressure = kip.Pkc.Pressure,
                     Consumption =
                     {
                        Ms = kip.Pkc.ConsumptionMs,
                        Ks = kip.Pkc.ConsumptionKs,
                     },
                     Temperature = kip.Pkc.Temperature,
                  },
                  Uvtp =
                  {
                     Pressure = kip.Uvtp.Pressure,
                     Consumption = { Value = kip.Uvtp.Consumption },
                     Temperature = kip.Uvtp.Temperature,
                  },
               },
               Spo =
               {
                  Pressure = kip.Spo.Pressure,
                  Consumption = { Value = kip.Spo.Consumption },
                  Temperature = kip.Spo.Temperature,
               }
            },
            Gru =
            {
               Gru1 =
               {
                  Pressure = kip.Gru1.Pressure,
                  Consumption = { Value = kip.Gru1.Consumption },
                  Temperature = kip.Gru1.Temperature,
               },
               Gru2 =
               {
                  Pressure = kip.Gru2.Pressure,
                  Consumption = { Value = kip.Gru2.Consumption },
                  Temperature = kip.Gru2.Temperature,
               },
            },
            Gsuf45 =
            {
               Pressure = kip.Gsuf45.Pressure,
               Consumption = { Value = kip.Gsuf45.Consumption },
               Temperature = kip.Gsuf45.Temperature,
            },
            Grp4 =
            {
               Pressure = kip.Grp4.Pressure,
               Consumption = { Value = kip.Grp4.Consumption },
               Temperature = kip.Grp4.Temperature,
            },
         };
      }

      public bool Upsert(DevicesKipDTO entity)
      {
         throw new NotImplementedException();
      }

      public IEnumerable<DevicesKipDTO> GetItemsByYear(int Year)
      {
         return db.DevicesKip.GetPerYear(Year).Select(p => ToDTO(p));
      }

      public IEnumerable<DevicesKipDTO> GetItemsByNowYear()
      {
         int Year = DateTime.Now.Year;
         return db.DevicesKip.GetPerYear(Year).Select(p => ToDTO(p));
      }
   }
}
