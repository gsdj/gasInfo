using BLL.DTO.Input;
using BLL.Interfaces.Services.Input;
using DA.Entities;
using DA.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services.Input
{
   public class DevicesKipService : IDevicesKipService
   {
      IUnitOfWork Db;
      public DevicesKipService(IUnitOfWork uof)
      {
         Db = uof;
      }
      public DevicesKipDTO GetItemByDate(DateTime Date)
      {
         var devices = Db.DevicesKip.GetByDate(Date);
         return ToDTO(devices);        
      }

      public IEnumerable<DevicesKipDTO> GetItemsByMonth(DateTime Date)
      {
         return Db.DevicesKip.GetPerMonth(Date.Year, Date.Month).Select(p => ToDTO(p));
      }

      public IEnumerable<DevicesKipDTO> GetItemsByNowMonth()
      {
         DateTime dateNow = DateTime.Now;
         return Db.DevicesKip.GetPerMonth(dateNow.Year,dateNow.Month).Select(p => ToDTO(p));
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
                     Ms = kip.Cb7.Consumption.Ms,
                     Ks = kip.Cb7.Consumption.Ks,
                  },
                  Temperature = kip.Cb7.Temperature,
                  TempBeforeHeating = kip.Cb7.TempBeforeHeating
               },
               Cb4 =
               {
                  Pressure = kip.Cb8.Pressure,
                  Consumption =
                  {
                     Ms = kip.Cb8.Consumption.Ms,
                     Ks = kip.Cb8.Consumption.Ks,
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
                        Ms = kip.Pkc.Consumption.Ms,
                        Ks = kip.Pkc.Consumption.Ks,
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

      public bool InsertOrUpdate(DevicesKipDTO entity)
      {
         DevicesKip d = Db.DevicesKip.GetByDate(entity.Date) ?? new DevicesKip();
         try
         {
            d.Date = entity.Date;
            /*Cu*/
            d.Cu1.Consumption = (int)entity.Cu.Cu1.Consumption.Value;
            d.Cu1.Temperature = entity.Cu.Cu1.Temperature;
            d.Cu1.Pressure = entity.Cu.Cu1.Pressure;
            d.Cu2.Consumption = (int)entity.Cu.Cu2.Consumption.Value;
            d.Cu2.Temperature = entity.Cu.Cu2.Temperature;
            d.Cu2.Pressure = entity.Cu.Cu2.Pressure;
            /*---*/
            /*Kc1*/
            d.Cb1.Consumption = (int)entity.Kc1.Cb1.Consumption.Value;
            d.Cb1.Temperature = entity.Kc1.Cb1.Temperature;
            d.Cb1.Pressure = entity.Kc1.Cb1.Pressure;
            d.Cb2.Consumption = (int)entity.Kc1.Cb2.Consumption.Value;
            d.Cb2.Temperature = entity.Kc1.Cb2.Temperature;
            d.Cb2.Pressure = entity.Kc1.Cb2.Pressure;
            d.Cb3.Consumption = (int)entity.Kc1.Cb3.Consumption.Value;
            d.Cb3.Temperature = entity.Kc1.Cb3.Temperature;
            d.Cb3.Pressure = entity.Kc1.Cb3.Pressure;
            d.Cb4.Consumption = (int)entity.Kc1.Cb4.Consumption.Value;
            d.Cb4.Temperature = entity.Kc1.Cb4.Temperature;
            d.Cb4.Pressure = entity.Kc1.Cb4.Pressure;
            /*---*/
            /*Kc2*/
            d.Cb5.Consumption = (int)entity.Kc2.Cb1.Consumption.Value;
            d.Cb5.Temperature = entity.Kc2.Cb1.Temperature;
            d.Cb5.Pressure = entity.Kc2.Cb1.Pressure;
            d.Cb5.TempBeforeHeating = entity.Kc2.Cb1.TempBeforeHeating;

            d.Cb6.Consumption = (int)entity.Kc2.Cb2.Consumption.Value;
            d.Cb6.Temperature = entity.Kc2.Cb2.Temperature;
            d.Cb6.Pressure = entity.Kc2.Cb2.Pressure;
            d.Cb6.TempBeforeHeating = entity.Kc2.Cb2.TempBeforeHeating;

            d.Cb7.Consumption.Ms = (int)entity.Kc2.Cb3.Consumption.Ms;
            d.Cb7.Consumption.Ks = (int)entity.Kc2.Cb3.Consumption.Ks;
            d.Cb7.Temperature = entity.Kc2.Cb3.Temperature;
            d.Cb7.Pressure = entity.Kc2.Cb3.Pressure;
            d.Cb7.TempBeforeHeating = entity.Kc2.Cb3.TempBeforeHeating;

            d.Cb8.Consumption.Ms = (int)entity.Kc2.Cb4.Consumption.Ms;
            d.Cb8.Consumption.Ks = (int)entity.Kc2.Cb4.Consumption.Ks;
            d.Cb8.Temperature = entity.Kc2.Cb4.Temperature;
            d.Cb8.Pressure = entity.Kc2.Cb4.Pressure;
            d.Cb8.TempBeforeHeating = entity.Kc2.Cb4.TempBeforeHeating;
            /*---*/
            /*CpsPpk*/
            d.Pkc.Consumption.Ms = entity.CpsPpk.Pko.Pkp.Consumption.Ms;
            d.Pkc.Consumption.Ks = entity.CpsPpk.Pko.Pkp.Consumption.Ks;
            d.Pkc.Pressure = entity.CpsPpk.Pko.Pkp.Pressure;
            d.Pkc.Temperature = entity.CpsPpk.Pko.Pkp.Temperature;

            d.Spo.Consumption = (int)entity.CpsPpk.Spo.Consumption.Value;
            d.Spo.Pressure = entity.CpsPpk.Spo.Pressure;
            d.Spo.Temperature = entity.CpsPpk.Spo.Temperature;

            d.Uvtp.Consumption = (int)entity.CpsPpk.Pko.Uvtp.Consumption.Value;
            d.Uvtp.Pressure = entity.CpsPpk.Pko.Uvtp.Pressure;
            d.Uvtp.Temperature = entity.CpsPpk.Pko.Uvtp.Temperature;

            d.Gsuf45.Consumption = (int)entity.Gsuf45.Consumption.Value;
            d.Gsuf45.Pressure = entity.Gsuf45.Pressure;
            d.Gsuf45.Temperature = entity.Gsuf45.Temperature;

            d.Gru1.Consumption = (int)entity.Gru.Gru1.Consumption.Value;
            d.Gru1.Pressure = entity.Gru.Gru1.Pressure;
            d.Gru1.Temperature = entity.Gru.Gru1.Temperature;

            d.Gru2.Consumption = (int)entity.Gru.Gru2.Consumption.Value;
            d.Gru2.Pressure = entity.Gru.Gru2.Pressure;
            d.Gru2.Temperature = entity.Gru.Gru2.Temperature;

            d.Grp4.Consumption = (int)entity.Grp4.Consumption.Value;
            d.Grp4.Pressure = entity.Grp4.Pressure;
            d.Grp4.Temperature = entity.Grp4.Temperature;
            /*------*/

            if (d.Id > 0)
            {
               Db.DevicesKip.Update(d);
            }
            else
            {
               Db.DevicesKip.Create(d);
            }
            return true;
         }
         catch (Exception ex)
         {
            return false;
         }
      }

      public IEnumerable<DevicesKipDTO> GetItemsByYear(int Year)
      {
         return Db.DevicesKip.GetPerYear(Year).Select(p => ToDTO(p));
      }

      public IEnumerable<DevicesKipDTO> GetItemsByNowYear()
      {
         int Year = DateTime.Now.Year;
         return Db.DevicesKip.GetPerYear(Year).Select(p => ToDTO(p));
      }
   }
}
