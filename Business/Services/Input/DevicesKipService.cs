using Business.DTO;
using Business.Interfaces.Services;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
         return GetItemsByDate(Date);
      }

      public IEnumerable<DevicesKipDTO> GetItemsByNowMonth()
      {
         DateTime dateNow = DateTime.Now;
         return GetItemsByDate(dateNow);         
      }

      private IEnumerable<DevicesKipDTO> GetItemsByDate(DateTime Date)
      {
         return db.DevicesKip.GetPerMonth(Date.Year, Date.Month).Select(p => new DevicesKipDTO
         {
            Date = p.Date,
            Cb1 =
            {
               Pressure = p.Cb1.Pressure,
               Consumption = p.Cb1.Consumption,
               Temperature = p.Cb1.Temperature,
            },
            Cb2 =
            {
               Pressure = p.Cb2.Pressure,
               Consumption = p.Cb2.Consumption,
               Temperature = p.Cb2.Temperature,
            },
            Cb3 =
            {
               Pressure = p.Cb3.Pressure,
               Consumption = p.Cb3.Consumption,
               Temperature = p.Cb3.Temperature,
            },
            Cb4 =
            {
               Pressure = p.Cb4.Pressure,
               Consumption = p.Cb4.Consumption,
               Temperature = p.Cb4.Temperature,
            },
            Cb5 =
            {
               Pressure = p.Cb5.Pressure,
               Consumption = p.Cb5.Consumption,
               Temperature = p.Cb5.Temperature,
               TempBeforeHeating = p.Cb5.TempBeforeHeating,
            },
            Cb6 =
            {
               Pressure = p.Cb6.Pressure,
               Consumption = p.Cb6.Consumption,
               Temperature = p.Cb6.Temperature,
               TempBeforeHeating = p.Cb6.TempBeforeHeating,
            },
            Cb7 =
            {
               Pressure = p.Cb7.Pressure,
               ConsumptionMs = p.Cb7.ConsumptionMs,
               ConsumptionKs = p.Cb7.ConsumptionKs,
               Temperature = p.Cb7.Temperature,
               TempBeforeHeating = p.Cb7.TempBeforeHeating
            },
            Cb8 =
            {
               Pressure = p.Cb8.Pressure,
               ConsumptionMs = p.Cb8.ConsumptionMs,
               ConsumptionKs = p.Cb8.ConsumptionKs,
               Temperature = p.Cb8.Temperature,
               TempBeforeHeating = p.Cb8.TempBeforeHeating
            },
            Cu1 =
            {
               Pressure = p.Cu1.Pressure,
               Consumption = p.Cu1.Consumption,
               Temperature = p.Cu1.Temperature,
            },
            Cu2 =
            {
               Pressure = p.Cu2.Pressure,
               Consumption = p.Cu2.Consumption,
               Temperature = p.Cu2.Temperature,
            },
            Pkc =
            {
               Pressure = p.Pkc.Pressure,
               ConsumptionMs = p.Pkc.ConsumptionMs,
               ConsumptionKs = p.Pkc.ConsumptionKs,
               Temperature = p.Pkc.Temperature,
            },
            Spo =
            {
               Pressure = p.Spo.Pressure,
               Consumption = p.Spo.Consumption,
               Temperature = p.Spo.Temperature,
            },
            Uvtp =
            {
               Pressure = p.Uvtp.Pressure,
               Consumption = p.Uvtp.Consumption,
               Temperature = p.Uvtp.Temperature,
            },
            Gru1 = 
            {
               Pressure = p.Gru1.Pressure,
               Consumption = p.Gru1.Consumption,
               Temperature = p.Gru1.Temperature,
            },
            Gru2 =
            {
               Pressure = p.Gru2.Pressure,
               Consumption = p.Gru2.Consumption,
               Temperature = p.Gru2.Temperature,
            },
            Gsuf45 =
            {
               Pressure = p.Gsuf45.Pressure,
               Consumption = p.Gsuf45.Consumption,
               Temperature = p.Gsuf45.Temperature,
            },
            Grp4 =
            {
               Pressure = p.Grp4.Pressure,
               Consumption = p.Grp4.Consumption,
               Temperature = p.Grp4.Temperature,
            },
         });
      }

      public void Insert(DevicesKipDTO entity)
      {
         throw new NotImplementedException();
      }

      public void Upsert(DevicesKipDTO entity)
      {
         throw new NotImplementedException();
      }
   }
}
