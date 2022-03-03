using Business.DTO;
using Business.Interfaces.Calculations;
using Business.Interfaces.Services;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
   public class ConsumptionKgService : IConsumptionKgService
   {
      IUnitOfWork db;
      ICalcConsumptionKg CalcConsKg;
      ICalcCharacteristicsKg CalcCharKg;
      ICalcCharacteristicsDg CalcCharDg;
      ICalcWetGasDensity CalcWetGas;
      ICalcDryGasDensity CalcDryGas;
      ICalcCharacteristicsSteam CalcCharSteam;
      public ConsumptionKgService(IUnitOfWork uof, ICalcConsumptionKg calcConsKg,
                                    ICalcCharacteristicsKg calcCharKg, ICalcCharacteristicsDg calcCharDg,
                                    ICalcWetGasDensity calcWetGas, ICalcDryGasDensity calcDryGas, ICalcCharacteristicsSteam calcCharSteam)
      {
         db = uof;
         CalcConsKg = calcConsKg;
         CalcCharKg = calcCharKg;
         CalcCharDg = calcCharDg;
         CalcWetGas = calcWetGas;
         CalcDryGas = calcDryGas;
         CalcCharSteam = calcCharSteam;
      }
      public IEnumerable<ConsumptionKgDTO> GetItemsByMonth(DateTime Date)
      {
         throw new NotImplementedException();
      }

      public IEnumerable<ConsumptionKgDTO> GetItemsByNowMonth()
      {
         DateTime dateNow = DateTime.Now;
         var charKg = CalcCharKg.CalcEntities(db.CharacteristicsKg.GetPerMonth(dateNow.Year, dateNow.Month));
         var charDg = CalcCharDg.CalcEntities(db.CharacteristicsDg.GetPerMonth(dateNow.Year, dateNow.Month));
         var pressure = db.Pressure.GetPerMonth(dateNow.Year, dateNow.Month).Select(p => new PressureDTO
         {
            Date = p.Date,
            Value = p.Value
         });
         var kip = db.DevicesKip.GetPerMonth(dateNow.Year, dateNow.Month);
         var kip2 = db.DevicesKip.GetPerMonth(dateNow.Year, dateNow.Month).Select(p => new DevicesKipDTO
         {
            Date = p.Date,
         });
         var steam = CalcCharSteam.CalcEntities(db.SteamCharacteristics.GetAll());
         var dryGas = CalcDryGas.CalcEntities(pressure, charKg, charDg, kip, steam);
         var wetGas = CalcWetGas.CalcEntities(dryGas, kip, steam);
         var consKg = CalcConsKg.CalcEntities(wetGas, kip2, charKg, steam);
         return consKg;
      }
   }
}
