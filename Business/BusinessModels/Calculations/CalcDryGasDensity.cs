using Business.DTO;
using Business.DTO.Characteristics;
using Business.Interfaces.Calculations;
using Bussiness.BusinessModels;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessModels.Calculations
{
   public class CalcDryGasDensity : ICalcDryGasDensity
   {
      private Dictionary<int, SteamCharacteristicsDTO> _steam;
      public IEnumerable<DensityDTO> CalcEntities(IEnumerable<PressureDTO> pressure, IEnumerable<CharacteristicsKgDTO> kgs, 
                                                  IEnumerable<CharacteristicsDgDTO> dgs, IEnumerable<DevicesKip> kip,
                                                  Dictionary<int, SteamCharacteristicsDTO> steam)
      {
         _steam = steam;
         var d =
             from t1p in pressure
             join t2kgs in kgs on new { t1p.Date } equals new { t2kgs.Date }
             join t3dgs in dgs on new { t2kgs.Date } equals new { t3dgs.Date }
             join t4kip in kip on new { t3dgs.Date } equals new { t4kip.Date }
             select new
             {
                Pressure = t1p,
                Kgs = t2kgs,
                Dgs = t3dgs,
                Kip = t4kip
             };

         List<DensityDTO> densityDry = new List<DensityDTO>(d.Count());
         foreach (var item in d)
         {
            densityDry.Add(CalcEntity(item.Pressure, item.Kgs, item.Dgs, item.Kip));
         }
         return densityDry;
      }

      public DensityDTO CalcEntity(PressureDTO pressure, CharacteristicsKgDTO kg, 
                                   CharacteristicsDgDTO dg, DevicesKip kip)
      {
         return new DensityDTO
         {
            Date = pressure.Date,
            Cu1 = (kip.Cu1.Pressure == 0) ? 0 : DryGas(kg.Kc1.Characteristics.Density, pressure.ValuePa, kip.Cu1.Pressure, kip.Cu1.Temperature),
            Cu2 = (kip.Cu2.Pressure == 0) ? 0 : DryGas(kg.Kc2.Characteristics.Density, pressure.ValuePa, kip.Cu2.Pressure, kip.Cu2.Temperature),
            Cb5 = (kip.Cb5.Pressure == 0) ? 0 : DryGas(kg.Kc1.Characteristics.Density, pressure.ValuePa, kip.Cb5.Pressure, kip.Cb5.Temperature, kip.Cb5.TempBeforeHeating),
            Cb6 = (kip.Cb6.Pressure == 0) ? 0 : DryGas(kg.Kc1.Characteristics.Density, pressure.ValuePa, kip.Cb6.Pressure, kip.Cb6.Temperature, kip.Cb6.TempBeforeHeating),
            Cb7 = (kip.Cb7.Pressure == 0) ? 0 : DryGas(kg.Kc2.Characteristics.Density, pressure.ValuePa, kip.Cb7.Pressure, kip.Cb7.Temperature, kip.Cb7.TempBeforeHeating),
            Cb8 = (kip.Cb7.Pressure == 0) ? 0 : DryGas(kg.Kc2.Characteristics.Density, pressure.ValuePa, kip.Cb8.Pressure, kip.Cb8.Temperature, kip.Cb8.TempBeforeHeating),
            Pkc = (kip.Pkc.Pressure == 0) ? 0 : DryGas(kg.Kc1.Characteristics.Density, pressure.ValuePa, kip.Pkc.Pressure, kip.Pkc.Temperature),
            Uvtp = (kip.Uvtp.Pressure == 0) ? 0 : DryGas(kg.Kc1.Characteristics.Density, pressure.ValuePa, kip.Uvtp.Pressure, kip.Uvtp.Temperature),
            Spo = (kip.Spo.Pressure == 0) ? 0 : DryGas(kg.Kc1.Characteristics.Density, pressure.ValuePa, kip.Spo.Pressure, kip.Spo.Temperature),
            Gsuf = (kip.Gsuf45.Pressure == 0) ? 0 : DryGas(kg.Kc1.Characteristics.Density, pressure.ValuePa, kip.Gsuf45.Pressure, kip.Gsuf45.Temperature),
            Cb1 = (dg.CharacteristicsAVG.Density == 0 || kip.Cb1.Pressure == 0) ? 0 : DryGas(dg.CharacteristicsAVG.Density, pressure.ValuePa, kip.Cb1.Pressure, kip.Cb1.Temperature),
            Cb2 = (dg.CharacteristicsAVG.Density == 0 || kip.Cb2.Pressure == 0) ? 0 : DryGas(dg.CharacteristicsAVG.Density, pressure.ValuePa, kip.Cb2.Pressure, kip.Cb2.Temperature),
            Cb3 = (dg.CharacteristicsAVG.Density == 0 || kip.Cb3.Pressure == 0) ? 0 : DryGas(dg.CharacteristicsAVG.Density, pressure.ValuePa, kip.Cb3.Pressure, kip.Cb3.Temperature),
            Cb4 = (dg.CharacteristicsAVG.Density == 0 || kip.Cb4.Pressure == 0) ? 0 : DryGas(dg.CharacteristicsAVG.Density, pressure.ValuePa, kip.Cb4.Pressure, kip.Cb4.Temperature),
         };
      }

      public decimal DryGas(decimal pkg, decimal PPa, decimal pOver, decimal temp)
      {
         int tempRounded = Convert.ToInt32(Math.Round(temp, MidpointRounding.ToEven));
         var steam = _steam[tempRounded];
         decimal rH = steam.Rh;
         decimal pMax = steam.PPa;

         decimal result = DryGas(pkg, PPa, pOver, temp, rH, pMax);
         return Math.Round(result, 15);
      }

      public decimal DryGas(decimal pkg, decimal PPa, decimal pOver, decimal temp, decimal tempDo)
      {
         int tempRounded = Convert.ToInt32(Math.Round(temp, MidpointRounding.ToEven));
         int tempDoRounded = Convert.ToInt32(Math.Round(tempDo, MidpointRounding.ToEven));
         decimal pMax = _steam[tempRounded].PPa;
         decimal rH = _steam[tempDoRounded].Rh;

         decimal result = DryGas(pkg, PPa, pOver, temp, rH, pMax);
         return Math.Round(result, 15);
      }

      public decimal DryGas(decimal pkg, decimal PPa, decimal pOver, decimal temp, decimal rH, decimal pMax)
      {
         decimal result = pkg * (Constants.Tc * ((PPa + pOver * Constants.PexcC) - rH * pMax)) / (Constants.Pc * (Constants.TpC + temp) * Constants.K);
         return result;
      }
   }
}
