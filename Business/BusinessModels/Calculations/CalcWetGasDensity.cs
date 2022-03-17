using Business.BusinessModels.DataForCalculations;
using Business.DTO;
using Business.DTO.Characteristics;
using Business.Interfaces;
using Business.Interfaces.BaseCalculations;
using Business.Interfaces.Calculations;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.BusinessModels.Calculations
{
   public class CalcWetGasDensity : ICalculations<DensityDTO>, ICalculation<DensityDTO>, IWetDensity, IDryDensity
   {
      private Dictionary<int, SteamCharacteristicsDTO> _steam;
      private IConstantsAll _cAll;
      private Constants Constants;
      public CalcWetGasDensity(IConstantsAll cAll)
      {
         _cAll = cAll;
         Constants = _cAll.GetConstants();
         _steam = _cAll.GetSteamCharacteristics();
      }
      private DensityDTO CalcDryGasDensity(PressureDTO pressure, CharacteristicsKgDTO kg, CharacteristicsDgDTO dg, DevicesKipDTO kip)
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
      public DensityDTO CalcEntity(Data data)
      {
         GasDensityData Data = data as GasDensityData;

         var dryGas = CalcDryGasDensity(Data.Pressure, Data.CharacteristicsKg, Data.CharacteristicsDg, Data.Kip);
         var kip = Data.Kip;

         return new DensityDTO
         {
            Date = dryGas.Date,
            Cu1 = WetGas(dryGas.Cu1, kip.Cu1.Temperature),
            Cu2 = WetGas(dryGas.Cu2, kip.Cu2.Temperature),
            Cb5 = WetGas(dryGas.Cb5, kip.Cb5.Temperature),
            Cb6 = WetGas(dryGas.Cb6, kip.Cb6.Temperature),
            Cb7 = WetGas(dryGas.Cb7, kip.Cb7.Temperature),
            Cb8 = WetGas(dryGas.Cb8, kip.Cb8.Temperature),
            Pkc = WetGas(dryGas.Pkc, kip.Pkc.Temperature),
            Uvtp = WetGas(dryGas.Uvtp, kip.Uvtp.Temperature),
            Spo = WetGas(dryGas.Spo, kip.Spo.Temperature),
            Gsuf = WetGas(dryGas.Gsuf, kip.Gsuf45.Temperature),
            Cb1 = WetGas(dryGas.Cb1, kip.Cb1.Temperature),
            Cb2 = WetGas(dryGas.Cb2, kip.Cb2.Temperature),
            Cb3 = WetGas(dryGas.Cb3, kip.Cb3.Temperature),
            Cb4 = WetGas(dryGas.Cb4, kip.Cb4.Temperature),
         };
      }

      public IEnumerable<DensityDTO> CalcEntities(EnumerableData data)
      {
         var Data = data as GasDensityEnumData;

         var kip = Data.Kip;
         var charKg = Data.CharacteristicsKg;
         var charDg = Data.CharacteristicsDg;
         var pressure = Data.Pressure;

         var d = from t1charKg in charKg
                 join t2charDg in charDg on new { t1charKg.Date } equals new { t2charDg.Date }
                 join t3kip in kip on new { t2charDg.Date } equals new { t3kip.Date }
                 join t4pressure in pressure on new { t3kip.Date } equals new { t4pressure.Date }
                 select new GasDensityData
                 {
                    CharacteristicsKg = t1charKg,
                    CharacteristicsDg = t2charDg,
                    Kip = t3kip,
                    Pressure = t4pressure,
                 };

         List<DensityDTO> densityWet = new List<DensityDTO>(d.Count());
         foreach (var item in d)
         {
            densityWet.Add(CalcEntity(item));
         }
         return densityWet;
      }

      public decimal WetGas(decimal dryGas, decimal temp)
      {
         int tempRounded = Convert.ToInt32(Math.Round(temp, MidpointRounding.ToEven));
         var steam = _steam[tempRounded];
         decimal rH = steam.Rh;
         decimal pMax = steam.PKg;

         decimal result = dryGas + rH * pMax;
         return Math.Round(result, 15);
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
